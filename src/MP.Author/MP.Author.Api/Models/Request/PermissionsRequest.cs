using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MP.Author.Api.Models.Request
{
    public class PermissionsRequest
    {
        public int Id { get; set; }
        public int ObjectId { get; set; }
        public int OperationId { get; set; }
    }
}
