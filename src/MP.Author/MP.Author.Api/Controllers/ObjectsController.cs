using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MP.Author.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ObjectsController : ControllerBase
    {
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] Models.Request.ObjectsRequest request)
        {
            if (!ModelState.IsValid) { return BadRequest(ModelState); }

            return Ok();            
        }
    }
}