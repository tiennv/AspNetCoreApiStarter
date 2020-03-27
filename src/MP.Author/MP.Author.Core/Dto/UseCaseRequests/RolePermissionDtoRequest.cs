using MP.Author.Core.Dto.UseCaseResponses;
using MP.Author.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MP.Author.Core.Dto.UseCaseRequests
{
    public class RolePermissionDtoRequest : IUseCaseRequest<RolePermissionDtoResponse>
    {
        public int Id { get; set; }
        public string RoleId { get; set; }
        public int PermissionId { get; set; }
    }
}
