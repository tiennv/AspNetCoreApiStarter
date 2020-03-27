using MP.Author.Core.Dto.UseCaseRequests;
using MP.Author.Core.Dto.UseCaseResponses;
using System;
using System.Collections.Generic;
using System.Text;

namespace MP.Author.Core.Interfaces.UseCases
{
    public interface ILogoutUseCase : IUseCaseRequestHandler<LogoutDtoRequest, LogoutDtoResponse>
    {
    }
}
