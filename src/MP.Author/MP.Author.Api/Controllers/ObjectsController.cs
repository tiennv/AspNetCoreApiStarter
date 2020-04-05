﻿using System;
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
    public class ObjectsController : ControllerBase
    {
        private readonly IObjectsUseCase _objectsUserCase;
        private readonly ObjectsPresenter _objectsPresenter;
        private readonly IMapper _mapper;

        public ObjectsController(IObjectsUseCase objectsUserCase, ObjectsPresenter objectsPresenter, IMapper mapper)
        {
            _objectsUserCase = objectsUserCase;
            _objectsPresenter = objectsPresenter;
            _mapper = mapper;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> Get(int id)
        {
            await _objectsUserCase.Get(id, _objectsPresenter);
            return _objectsPresenter.ContentResult;
        }

        [HttpGet("all")]
        public async Task<ActionResult> Gets()
        {
            await _objectsUserCase.Gets(_objectsPresenter);
            return _objectsPresenter.ContentResult;
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] ObjectsRequest request)
        {
            if (!ModelState.IsValid) { return BadRequest(ModelState); }
            var requestDto = _mapper.Map<ObjectsRequest, ObjectsDtoRequest>(request);
            await _objectsUserCase.Handle(requestDto, _objectsPresenter);
            return _objectsPresenter.ContentResult;
        }

        [HttpPut]
        public async Task<ActionResult> Put([FromBody] ObjectsRequest request)
        {
            if (!ModelState.IsValid) { return BadRequest(ModelState); }
            var requestDto = _mapper.Map<ObjectsRequest, ObjectsDtoRequest>(request);
            await _objectsUserCase.Update(requestDto, _objectsPresenter);
            return _objectsPresenter.ContentResult;
        }

        [HttpPost("list")]
        public async Task<ActionResult> PostList([FromBody] List<ObjectsRequest> request)
        {
            if (!ModelState.IsValid) { return BadRequest(ModelState); }
            var requestDtos = _mapper.Map<List<ObjectsRequest>, List<ObjectsDtoRequest>>(request);
            await _objectsUserCase.Create(requestDtos, _objectsPresenter);
            return _objectsPresenter.ContentResult;
        }

        [HttpDelete]
        public async Task<ActionResult> Delete([FromBody]List<int> requests)
        {
            if (!ModelState.IsValid) { return BadRequest(ModelState); }
            await _objectsUserCase.Delete(requests.Select(x => new ObjectsDtoRequest(id: x)).ToList(), _objectsPresenter);
            return _objectsPresenter.ContentResult;
        }
    }
}