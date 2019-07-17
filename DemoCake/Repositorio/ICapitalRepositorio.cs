using System;
using System.Collections.Generic;
using DemoCake.Models;

namespace DemoCake.Repositorio
{
    public interface ICapitalRepositorio
    {
        IEnumerable<Capital> Todas();
        Capital PorEstado(string estado);
        Capital PorSilga(string sigla);
    }
}
