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
using MP.Author.Core.Dto.UseCaseResponses;
using MP.Author.Core.Interfaces.UseCases;

namespace MP.Author.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private readonly IRegisterUserUseCase _registerUserUseCase;
        private readonly IUserRoleUserCase _userRoleUserCase;
        private readonly RegisterUserPresenter _registerUserPresenter;
        private readonly UserRolePresenter _userRolePresenter;
        private readonly IMapper _mapper;

        public AccountsController(IRegisterUserUseCase registerUserUseCase, RegisterUserPresenter registerUserPresenter, 
            IUserRoleUserCase userRoleUserCase, UserRolePresenter userRolePresenter,
            IMapper mapper)
        {
            _registerUserUseCase = registerUserUseCase;
            _registerUserPresenter = registerUserPresenter;
            _userRoleUserCase = userRoleUserCase;
            _userRolePresenter = userRolePresenter;
            _mapper = mapper;
        }

        // POST api/accounts
        [HttpPost]
        public async Task<ActionResult> Post([FromBody]RegisterUserRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await _registerUserUseCase.Handle(new RegisterUserDtoRequest(request.FirstName, request.LastName, request.Email, request.UserName, request.Password), _registerUserPresenter);
            return _registerUserPresenter.ContentResult;
        }

        [HttpPost("add-roles")]
        [ServiceFilter(typeof(SecurityFilter))]
        public async Task<ActionResult> AddRoles([FromBody] AddUserRoleRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var requestDto = _mapper.Map<AddUserRoleRequest, AddUserRoleDtoRequest>(request);

            await _userRoleUserCase.CreateAsync(requestDto, _userRolePresenter);            
            
            return _userRolePresenter.ContentResult;
        }

    }
}