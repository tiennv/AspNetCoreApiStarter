using MP.Author.Core.Dto.UseCaseResponses;
using MP.Author.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MP.Author.Core.Dto.UseCaseRequests
{
    public class RoleDtoRequest : IUseCaseRequest<RoleDtoResponse>
    {
        public string Id { get; }
        public string Name { get; }

        public RoleDtoRequest(string id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
