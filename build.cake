#addin "nuget:?package=Cake.Coverlet&version=2.3.4"
#addin nuget:?package=Cake.SemVer&version=3.0.0
#addin nuget:?package=semver&version=2.0.4
#addin nuget:?package=Cake.FileHelpers&version=3.0.0
#addin nuget:?package=Newtonsoft.Json&version=10.0.3
#addin nuget:?package=Cake.Json
#addin "Cake.Docker"

#tool "nuget:?package=ReportGenerator&version=4.1.8"
#tool "nuget:?package=NUnit.Runners&version=2.6.4"
#tool "dotnet:?package=coverlet.console&version=1.5.1"

#module "nuget:?package=Cake.DotNetTool.Module&version=0.3.0"

Task("DockerDemo")
.Does(() => {
   DockerRun(new DockerContainerRunSettings() {
            Detach = true,
            Name = "tdcDemo",
            Publish = new string[] {"1433:1433"},
            Env = new string[] {
               "ACCEPT_EULA=Y",
               "SA_PASSWORD=tdc@2019"
            }
         }, 
      "mcr.microsoft.com/mssql/server", "");
});

Task("NugetRestore")
  .Does(() =>
  {
    NuGetRestore("./DemoCake.sln");
  });

Task("RunAPI")
  .IsDependentOn("NugetRestore")
  .Does(() =>
  {
    DotNetCoreRun("./DemoCake");
  });

Task("BuildTest")
  .IsDependentOn("NugetRestore")
  .Does(() =>
  {
      DotNetCoreBuild("./DemoCake.Testes/DemoCake.Testes.csproj",
      new DotNetCoreBuildSettings
      {
          Verbosity = DotNetCoreVerbosity.Minimal,
          Configuration = "Debug",
          NoRestore = true
      });
  });

Task("Test")
  .IsDependentOn("BuildTest")
  .Does(() =>
  {
        if (DirectoryExists(@".\coverage-results"))
        {
            DeleteDirectory(@".\coverage-results\", new DeleteDirectorySettings()
            {
                Recursive = true
            });
        }

        var coverletSettings = new CoverletSettings {
            CollectCoverage = true,
            CoverletOutputFormat = CoverletOutputFormat.cobertura,
            CoverletOutputDirectory = Directory(@".\coverage-results\"),
            CoverletOutputName = $"results-{DateTime.UtcNow:dd-MM-yyyy-HH-mm-ss-FFF}"
        };

        Coverlet(
            new FilePath("./DemoCake.Testes/DemoCake.Testes.csproj"),
            coverletSettings);
  });

Task("ReportGenerator")
    .IsDependentOn("Test")
    .Does(() => {
        var reportGeneratorSettings = new ReportGeneratorSettings();

        ReportGenerator("./coverage-results/*.xml", "./coverage-results/ReportGeneratorOutput", reportGeneratorSettings);

        if (IsRunningOnUnix())
            StartProcess("open", "./coverage-results/ReportGeneratorOutput/index.htm");
        else
            StartProcess("explorer", ".\\coverage-results\\ReportGeneratorOutput\\index.htm");
    });

Task("TransformConfigs")
  .Does(() => {
        var configJson = ParseJsonFromFile("./DemoCake/appsettings.json");

        configJson["Ambiente"] = Argument<string>("Ambiente");
        
        SerializeJsonToPrettyFile("./DemoCake/appsettings.json", configJson);
  });

Task("ExemploCSharp")
    .Does(() =>
    {
        var lista = new List<string>();
       lista.Add("TDC");
       lista.Add("Trilha .Net");
 
        foreach (var item in lista)
        {
            Information(item);
        }
    });

var target = Argument("target", "Default");

Task("Default")
  .IsDependentOn("ReportGenerator")
  .Does(() =>
{
 
});

RunTarget(target);