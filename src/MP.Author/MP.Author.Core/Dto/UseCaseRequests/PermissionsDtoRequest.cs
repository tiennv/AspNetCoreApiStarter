using MP.Author.Core.Dto.UseCaseResponses;
using MP.Author.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MP.Author.Core.Dto.UseCaseRequests
{
    public class PermissionsDtoRequest : IUseCaseRequest<PermissionsDtoResponse>
    {
        public int Id { get; set; }
        public int ObjectId { get; set; }
        public int OperationId { get; set; }
        public string Name { get; set; }
    }
}
