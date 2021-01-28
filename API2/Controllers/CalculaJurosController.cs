using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Softplan.API2.Domain;
using Softplan.API2.Domain.Entities;
using Softplan.API2.Domain.Interfaces;

namespace Softplan.API2.Controllers
{
    [ApiController]
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class CalculaJurosController : ControllerBase
    {
        public readonly IServiceCalculaJuros _service;

        public CalculaJurosController(IServiceCalculaJuros service)
        {
            this._service = service;
        }

        /// <summary>
        /// Calcula a Taxa de Juros.
        /// </summary>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CalculaJurosDTO))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult CalculaJuros([FromQuery(Name = "valorInicial")] decimal valorInicial, [FromQuery(Name = "meses")] int meses)
        {
            try
            {
                if (valorInicial > 0 && meses > 0)
                {
                    CalculaJurosParametro param = new CalculaJurosParametro()
                    {
                        ValorInicial = valorInicial,
                        Meses = meses
                    };

                    var juros = this._service.CalculaJuros(param);
                    return Ok(juros);
                }

                return BadRequest("Os parâmetros ValorInicial e Meses são obrigatórios!");
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
