using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Softplan.API2.Domain.Entities;
using Softplan.API2.Domain.Interfaces;

namespace Softplan.API2.Controllers
{
    [ApiController]
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class ShowMeTheCodeController : ControllerBase
    {
        public readonly IShowMeTheCodeServices _service;

        public ShowMeTheCodeController(IShowMeTheCodeServices service)
        {
            this._service = service;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ShowMeTheCodeDTO))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult GetURLGit()
        {
            try
            {
                var url = this._service.GetURLGit();
                return Ok(url);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
