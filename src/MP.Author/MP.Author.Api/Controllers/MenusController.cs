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
    public class MenusController : ControllerBase
    {
        private readonly IMenusUseCase _menusUseCase;
        private readonly MenusPresenter _menusPresenter;
        private readonly IMapper _mapper;

        public MenusController(IMenusUseCase menusUseCase, MenusPresenter menusPresenter, IMapper mapper)
        {
            _menusPresenter = menusPresenter;
            _menusUseCase = menusUseCase;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] MenusRequest request)
        {
            if (!ModelState.IsValid) { return BadRequest(ModelState); }
            var requestDto = _mapper.Map<MenusDtoRequest>(request);
            await _menusUseCase.Add(requestDto, _menusPresenter);
            return _menusPresenter.ContentResult;
        }

        [HttpPut]
        public async Task<ActionResult> Put([FromBody] MenusRequest request)
        {
            if (!ModelState.IsValid) { return BadRequest(ModelState); }
            var requestDto = _mapper.Map<MenusDtoRequest>(request);
            await _menusUseCase.Update(requestDto, _menusPresenter);
            return _menusPresenter.ContentResult;
        }

        [HttpGet]
        public async Task<ActionResult> Gets()
        {            
            await _menusUseCase.Gets(_menusPresenter);
            return _menusPresenter.ContentResult;
        }
    }
}