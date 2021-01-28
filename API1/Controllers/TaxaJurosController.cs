using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Softplan.API1.Domain;
using Softplan.API1.Domain.Interfaces;

namespace Softplan.API1.Controllers
{
    [ApiController]
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class TaxaJurosController : ControllerBase
    {
        public readonly IServiceTaxaJuros _service;

        public TaxaJurosController(IServiceTaxaJuros service)
        {
            this._service = service;
        }

        /// <summary>
        /// Recupera a Taxa de Juros.
        /// </summary>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Juros))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult TaxaJuros()
        {
            try
            {
                var juros = this._service.GetTaxaJuros();
                return Ok(juros);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
