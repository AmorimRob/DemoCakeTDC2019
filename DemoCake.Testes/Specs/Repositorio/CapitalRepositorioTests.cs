using System.Linq;
using DemoCake.Repositorio;
using DemoCake.Testes.Support;
using FluentAssertions;
using NUnit.Framework;

namespace DemoCake.Testes.Specs.Repositorio
{
    public class CapitalRepositorioTests : TesteBase
    {
        [Test]
        public void DeveRetornarTodasAsCapitais()
        {
            var capitalRepo = new CapitalRepositorio();

            var result = capitalRepo.Todas();

            result.Should().NotBeEmpty();
        }

        [Test]
        public void DeveRetornarCapitaisPorEstado()
        {
            var capitalRepo = new CapitalRepositorio();

            var esperado = capitalRepo.Capitais.FirstOrDefault(x=> x.Estado == "São Paulo");
            var resultado = capitalRepo.PorEstado("São Paulo");

            esperado.Should().BeEquivalentTo(resultado);
        }

        [Test]
        public void DeveRetornarCapitaisPorSigla()
        {
            var capitalRepo = new CapitalRepositorio();

            var esperado = capitalRepo.Capitais.FirstOrDefault(x => x.Silga == "SP");
            var resultado = capitalRepo.PorSilga("SP");

            esperado.Should().BeEquivalentTo(resultado);
        }
    }
}
