using System;
using System.Collections.Generic;
using System.Text;

namespace MP.Author.Core.Dto.GatewayResponses.Repositories
{
    public class RoleResponse : BaseGatewayResponse
    {
        public string Id { get; }
        public string Name { get; }
        public RoleResponse(string id, string name, bool success = false, IEnumerable<Error> errors = null) : base(success, errors)
        {
            Id = id;
            Name = name;
        }
    }
}
