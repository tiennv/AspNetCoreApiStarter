using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MP.Author.Api.Middleware;
using MP.Author.Api.Models.Request;
using MP.Author.Api.Presenters;
using MP.Author.Core.Dto.UseCaseRequests;
using MP.Author.Core.Interfaces.UseCases;

namespace MP.Author.Api.Controllers
{
    [Route("api/[controller]")]
    [ServiceFilter(typeof(SecurityFilter))]
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

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] OperationsRequest request)
        {
            if (!ModelState.IsValid) { return BadRequest(ModelState); }
            var requestDto = _mapper.Map<OperationsRequest, OperationsDtoRequest>(request);
            await _operationsUserCase.Handle(requestDto, _operationsPresenter);
            return _operationsPresenter.ContentResult;
        }
    }
}