using MP.Author.Core.Dto.UseCaseRequests;
using MP.Author.Core.Dto.UseCaseResponses;
using MP.Author.Core.Interfaces;
using MP.Author.Core.Interfaces.Gateways.Repositories;
using MP.Author.Core.Interfaces.UseCases;
using System.Linq;
using System.Threading.Tasks;

namespace MP.Author.Core.UseCases
{
    public sealed class RegisterUserUseCase : IRegisterUserUseCase
    {
        private readonly IUserRepository _userRepository;
        private readonly IUserRoleRepository _userRoleRepository;

        public RegisterUserUseCase(IUserRepository userRepository, IUserRoleRepository userRoleRepository)
        {
            _userRepository = userRepository;
            _userRoleRepository = userRoleRepository;
        }

        public async Task<bool> Handle(RegisterUserDtoRequest message, IOutputPort<RegisterUserDtoResponse> outputPort)
        {
            var response = await _userRepository.Create(message.FirstName, message.LastName, message.Email, message.UserName, message.Password);
            outputPort.Handle(response.Success ? new RegisterUserDtoResponse(response.Id, true) : new RegisterUserDtoResponse(response.Errors.Select(e => e.Description)));
            return response.Success;
        }

        public async Task<bool> GetAllUser(IOutputPort<UserDtoResponse> outputPort)
        {
            var objUsers = await _userRepository.GetAllUser();
            // Get role 
            if(objUsers!=null && objUsers.Count > 0)
            {
                foreach (var item in objUsers)
                {
                    var objUserRole = await _userRoleRepository.GetRoleByUserId(item.UserId);
                    item.UserRoles = objUserRole;
                }
            }
            outputPort.Handle(new UserDtoResponse(objUsers, true, "", 200));
            return true;
        }
    }
}
