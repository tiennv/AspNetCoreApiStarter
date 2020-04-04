﻿using MP.Author.Core.Dto.UseCaseRequests;
using MP.Author.Core.Dto.UseCaseResponses;
using System.Threading.Tasks;

namespace MP.Author.Core.Interfaces.UseCases
{
    public interface IRegisterUserUseCase : IUseCaseRequestHandler<RegisterUserDtoRequest, RegisterUserDtoResponse>
    {
        Task<bool> GetAllUser(IOutputPort<UserDtoResponse> outputPort);
    }
}
