using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using MP.Author.Api.Middleware;
using MP.Author.Api.Models.Request;
using MP.Author.Api.Presenters;
using MP.Author.Core.Dto.UseCaseRequests;
using MP.Author.Core.Interfaces.UseCases;

namespace MP.Author.Api.Controllers
{
    [Route("api/[controller]")]
    //[ServiceFilter(typeof(SecurityFilter))]
    [ApiController]
    public class OperationsController : ControllerBase
    {
        private readonly IOperationsUserCase _operationsUserCase;
        private readonly OperationsPresenter _operationsPresenter;
        private readonly IMapper _mapper;

        public OperationsController(IOperationsUserCase operationsUserCase, OperationsPresenter operationsPresenter, IMapper mapper)
        {
            _operationsUserCase = operationsUserCase;
            _operationsPresenter = operationsPresenter;
            _mapper = mapper;
        }

        [HttpGet("get-by-object/{objectId}")]

        public async Task<ActionResult> GetByObject(int objectId)
        {
            await _operationsUserCase.GetByObject(objectId,_operationsPresenter);
            return _operationsPresenter.ContentResult;
        }

        [HttpGet("all")]
        public async Task<ActionResult> Gets()
        {
            await _operationsUserCase.Gets(_operationsPresenter);
            return _operationsPresenter.ContentResult;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> Get(int id)
        {
            await _operationsUserCase.Get(id, _operationsPresenter);
            return _operationsPresenter.ContentResult;
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] OperationsRequest request)
        {
            if (!ModelState.IsValid) { return BadRequest(ModelState); }
            var requestDto = _mapper.Map<OperationsRequest, OperationsDtoRequest>(request);
            await _operationsUserCase.Handle(requestDto, _operationsPresenter);
            return _operationsPresenter.ContentResult;
        }
        //[EnableCors("MPAuthorPolicy")]
        [HttpDelete]
        public async Task<ActionResult> Delete([FromBody] List<int> request)
        {
            if (!ModelState.IsValid) { return BadRequest(ModelState); }
            
            await _operationsUserCase.Delete(request.Select(x=> new OperationsDtoRequest(x)).ToList(), _operationsPresenter);
            return _operationsPresenter.ContentResult;
        }
    }
}