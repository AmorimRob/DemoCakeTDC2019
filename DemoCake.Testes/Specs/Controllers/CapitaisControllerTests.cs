using DemoCake.Controllers;
using DemoCake.Models;
using DemoCake.Repositorio;
using DemoCake.Testes.Support;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using NUnit.Framework;

namespace DemoCake.Testes.Specs.Controllers
{
    public class CapitaisControllerTests : TesteBase
    {
        [Test]
        public void DeveRetornarTodasAsCapitias()
        {
            var capitaisController = _autoFake.Resolve<CapitalController>();

            var result =  capitaisController.Get();

            result.Should().NotBeNull();
        }

        [Test]
        public void DeveRetornarACapitalDoEstadoPorEstado()
        {
            var capitaisController = new CapitalController(new CapitalRepositorio());

            var result = capitaisController.PorEstado("São Paulo").Result as OkObjectResult;

            ((Capital)result.Value).Nome.Should().Be("São Paulo");
        }

        [Test]
        public void DeveRetornarACapitalDoEstadoPorSigla()
        {
            var capitaisController = new CapitalController(new CapitalRepositorio());

            var result = capitaisController.PorSigla("SSA").Result as OkObjectResult;

            ((Capital)result.Value).Nome.Should().Be("Salvador");
        }

    }
}
