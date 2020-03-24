using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace AIC.Author.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PremissionController : ControllerBase
    {
        [HttpGet]
        public ActionResult Get(string token)
        {
            return new OkObjectResult(new { result = true, token });
        }

        [HttpPost]
        public ActionResult Post(string token)
        {
            return new OkObjectResult(new { result = true, token });
        }
    }
}