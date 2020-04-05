using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MP.Author.Api.Middleware;
using MP.Author.Api.Models.Request;
using MP.Author.Api.Presenters;
using MP.Author.Core.Dto.UseCaseRequests;
using MP.Author.Core.Interfaces.UseCases;

namespace MP.Author.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[ServiceFilter(typeof(SecurityFilter))]
    public class RoleController : ControllerBase
    {
        private readonly IRoleUseCase _roleUserCase;
        private readonly RolePresenter _rolePresenter;
        private readonly IMapper _mapper;

        public RoleController(IRoleUseCase roleUserCase, RolePresenter rolePresenter, IMapper mapper)
        {
            _mapper = mapper;
            _roleUserCase = roleUserCase;
            _rolePresenter = rolePresenter;
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] RoleRequest request)
        {
            if (!ModelState.IsValid) { return BadRequest(ModelState); }
            var requestDto = _mapper.Map<RoleRequest, RoleDtoRequest>(request);
            await _roleUserCase.Handle(requestDto, _rolePresenter);
            return _rolePresenter.ContentResult;
        }

        [HttpGet]
        public async Task<ActionResult> Gets()
        {           
            _roleUserCase.Gets(_rolePresenter);
            return _rolePresenter.ContentResult;
        }

        [HttpGet("get-by-user/{userId}")]
        public async Task<ActionResult> GetByUser(string userId)
        {
            await _roleUserCase.GetByUserAsync(userId, _rolePresenter);
            return _rolePresenter.ContentResult;
        }
    }
}