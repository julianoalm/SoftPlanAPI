using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Softplan.API2.Controllers
{
    public class ShowMeTheCodeController : ControllerBase
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
