using System;
using System.Collections.Generic;
using DemoCake.Repositorio;
using Microsoft.AspNetCore.Mvc;

namespace DemoCake.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CapitalController : ControllerBase
    {
        private readonly ICapitalRepositorio _capitalRepositorio;

        public CapitalController(ICapitalRepositorio capitalRepositorio)
        {
            _capitalRepositorio = capitalRepositorio;
        }

        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return Ok(_capitalRepositorio.Todas());
        }

        [HttpGet("estado/{estado}")]
        public ActionResult<string> PorEstado(string estado)
        {
            return Ok(_capitalRepositorio.PorEstado(estado));
        }

        [HttpGet("sigla/{sigla}")]
        public ActionResult<string> PorSigla(string sigla)
        {
            return Ok(_capitalRepositorio.PorSilga(sigla));
        }

    }
}
