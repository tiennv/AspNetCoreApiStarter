using MP.Author.Core.Dto.UseCaseResponses;
using MP.Author.Core.Interfaces;

namespace MP.Author.Core.Dto.UseCaseRequests
{
    public class RegisterUserDtoRequest : IUseCaseRequest<RegisterUserDtoResponse>
    {
        public string FirstName { get; }
        public string LastName { get; }
        public string Email { get; }
        public string UserName { get; }
        public string Password { get; }

        public RegisterUserDtoRequest(string firstName, string lastName, string email, string userName, string password)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            UserName = userName;
            Password = password;
        }
    }
}

