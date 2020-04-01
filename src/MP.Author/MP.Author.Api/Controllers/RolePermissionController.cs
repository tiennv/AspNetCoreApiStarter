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
    [ServiceFilter(typeof(SecurityFilter))]
    public class RolePermissionController : ControllerBase
    {
        private readonly IRolePermissionUserCase _rolePermissionsUserCase;
        private readonly RolePermissionPresenter _rolePermissionsPresenter;
        private readonly IMapper _mapper;

        public RolePermissionController(IMapper mapper, IRolePermissionUserCase rolePermissionsUserCase, RolePermissionPresenter rolePermissionsPresenter)
        {
            _mapper = mapper;
            _rolePermissionsUserCase = rolePermissionsUserCase;
            _rolePermissionsPresenter = rolePermissionsPresenter;
        }


        [HttpPost]
        public async Task<ActionResult> Post([FromBody] RolePermissionRequest request)
        {
            if (!ModelState.IsValid) { return BadRequest(ModelState); }
            var requestDto = _mapper.Map<RolePermissionRequest, RolePermissionDtoRequest>(request);
            await _rolePermissionsUserCase.Handle(requestDto, _rolePermissionsPresenter);
            return _rolePermissionsPresenter.ContentResult;
        }

        [HttpPost("list")]
        public async Task<ActionResult> PostList([FromBody] List<RolePermissionRequest> requests)
        {
            if (!ModelState.IsValid) { return BadRequest(ModelState); }
            var requestDto = _mapper.Map<List<RolePermissionRequest>, List<RolePermissionDtoRequest>>(requests);
            await _rolePermissionsUserCase.Create(requestDto, _rolePermissionsPresenter);
            return _rolePermissionsPresenter.ContentResult;
        }
    }
}