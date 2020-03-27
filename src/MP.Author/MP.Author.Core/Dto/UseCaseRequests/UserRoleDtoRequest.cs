using MP.Author.Core.Dto.UseCaseResponses;
using MP.Author.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MP.Author.Core.Dto.UseCaseRequests
{
    public class UserRoleDtoRequest : IUseCaseRequest<UserRoleDtoResponse>
    {
        public string UserId { get; }
        public string RoleId { get; }

        public UserRoleDtoRequest(string userId, string roleId)
        {
            UserId = userId;
            RoleId = roleId;
        }
    }
}
