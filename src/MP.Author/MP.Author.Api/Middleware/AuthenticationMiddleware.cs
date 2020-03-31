using Microsoft.AspNetCore.Http;

using MP.Author.Core.Interfaces.Services;
using System.Threading.Tasks;

namespace MP.Author.Api.Middleware
{
    public class AuthenticationMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IJwtTokenValidator _jwtTokenValidator;

        // Dependency Injection
        public AuthenticationMiddleware(RequestDelegate next, IJwtTokenValidator jwtTokenValidator)
        {
            _next = next;
            _jwtTokenValidator = jwtTokenValidator;
        }

        public async Task Invoke(HttpContext context)
        {
            //Reading the AuthHeader which is signed with JWT
            string authHeader = context.Request.Headers["Authorization"];

            if (authHeader != null)
            {
                var validation = _jwtTokenValidator.GetPrincipalFromToken(authHeader.ToString(), "tokenkey");
                //Pass to the next middleware
                await _next(context);
            }
            
        }
    }
}
