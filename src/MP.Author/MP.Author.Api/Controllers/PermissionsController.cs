using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MP.Author.Api.Models.Request;
using MP.Author.Api.Presenters;
using MP.Author.Core.Dto.UseCaseRequests;
using MP.Author.Core.Interfaces.UseCases;

namespace MP.Author.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PermissionsController : ControllerBase
    {
        private readonly IPermissionsUserCase _permissionsUserCase;
        private readonly PermissionsPresenter _permissionsPresenter;
        private readonly IMapper _mapper;

        public PermissionsController(IMapper mapper, IPermissionsUserCase permissionsUserCase, PermissionsPresenter permissionsPresenter)
        {
            _mapper = mapper;
            _permissionsUserCase = permissionsUserCase;
            _permissionsPresenter = permissionsPresenter;
        }


        [HttpPost]
        public async Task<ActionResult> Post([FromBody] PermissionsRequest request)
        {
            if (!ModelState.IsValid) { return BadRequest(ModelState); }
            var requestDto = _mapper.Map<PermissionsRequest, PermissionsDtoRequest>(request);
            await _permissionsUserCase.Handle(requestDto, _permissionsPresenter);
            return _permissionsPresenter.ContentResult;
        }

        [HttpPost("list")]
        public async Task<ActionResult> PostList([FromBody] List<PermissionsRequest> request)
        {
            if (!ModelState.IsValid) { return BadRequest(ModelState); }
            foreach (var item in request)
            {
                var requestDto = _mapper.Map<PermissionsRequest, PermissionsDtoRequest>(item);
                await _permissionsUserCase.Handle(requestDto, _permissionsPresenter);
            }
            return _permissionsPresenter.ContentResult;
        }
    }
}