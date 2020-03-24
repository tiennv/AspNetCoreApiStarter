using AIC.Author.Core.Dto.UseCaseRequests;
using AIC.Author.Core.Dto.UseCaseResponses;

namespace AIC.Author.Core.Interfaces.UseCases
{
    public interface IRegisterUserUseCase : IUseCaseRequestHandler<RegisterUserRequest, RegisterUserResponse>
    {
    }
}
