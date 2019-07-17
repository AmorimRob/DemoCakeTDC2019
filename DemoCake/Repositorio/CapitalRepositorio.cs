using System;
using System.Collections.Generic;
using DemoCake.Models;

namespace DemoCake.Repositorio
{
    public class CapitalRepositorio : ICapitalRepositorio
    {
        public List<Capital> Capitais { get; set; }

        public CapitalRepositorio()
        {
            Capitais = new List<Capital>();

            Capitais.Add(new Capital() { Estado = "São Paulo", Nome = "São Paulo", Pais = "Brasil", Silga = "SP" });
            Capitais.Add(new Capital() { Estado = "Rio de Janeiro", Nome = "Rio de Janeiro", Pais = "Brasil", Silga = "RJ" });
            Capitais.Add(new Capital() { Estado = "Rio Grande do Sul", Nome = "Porto Alegre", Pais = "Brasil", Silga = "PO" });
            Capitais.Add(new Capital() { Estado = "Bahia", Nome = "Salvador", Pais = "Brasil", Silga = "SSA" });
            Capitais.Add(new Capital() { Estado = "Espirito Santo", Nome = "Vitória", Pais = "Brasil", Silga = "VT" });
            Capitais.Add(new Capital() { Estado = "Minas Gerais", Nome = "Belo Horizonte", Pais = "Brasil", Silga = "BH" });
            Capitais.Add(new Capital() { Estado = "Pernambuco", Nome = "Recife", Pais = "Brasil", Silga = "REC" });
            Capitais.Add(new Capital() { Estado = "Paraná", Nome = "Curitiba", Pais = "Brasil", Silga = "CTBA" });
            Capitais.Add(new Capital() { Estado = "Santa Catarina", Nome = "Florianópolis", Pais = "Brasil", Silga = "FL" });

        }

        public Capital PorEstado(string estado)
        {
            return Capitais.Find(x => x.Estado.Equals(estado));
        }

        public Capital PorSilga(string sigla)
        {
            return Capitais.Find(x => x.Silga.Equals(sigla));
        }

        public IEnumerable<Capital> Todas()
        {
            return Capitais;
        }
    }
}
