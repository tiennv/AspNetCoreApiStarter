using MP.Author.Core.Shared;
using System;
using System.Collections.Generic;
using System.Text;

namespace MP.Author.Core.Domain.Entities
{
    public class Permissions : BaseEntity
    {
        public int ObjectId { get; set; }
        public int OperationId { get; set; }
        internal Permissions() { }
        internal Permissions(int objectId, int operationId)
        {
            OperationId = operationId;
            ObjectId = objectId;
        }
    }
}
