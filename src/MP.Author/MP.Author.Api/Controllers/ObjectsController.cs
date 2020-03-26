using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MP.Author.Core.Interfaces.UseCases;

namespace MP.Author.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ObjectsController : ControllerBase
    {
        private readonly IObjectsUserCase _objectsUserCase;

        public ObjectsController(IObjectsUserCase objectsUserCase)
        {
            _objectsUserCase = objectsUserCase;
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] Models.Request.ObjectsRequest request)
        {
            if (!ModelState.IsValid) { return BadRequest(ModelState); }
            
            return Ok();            
        }
    }
}