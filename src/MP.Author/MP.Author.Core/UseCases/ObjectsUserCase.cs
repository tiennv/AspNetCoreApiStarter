using MP.Author.Core.Dto.UseCaseRequests;
using MP.Author.Core.Dto.UseCaseResponses;
using MP.Author.Core.Interfaces;
using MP.Author.Core.Interfaces.UseCases;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MP.Author.Core.UseCases
{
    public class ObjectsUserCase : IObjectsUserCase
    {
        public Task<bool> Handle(ObjectsRequest message, IOutputPort<ObjectsResponse> outputPort)
        {
            throw new NotImplementedException();
        }
    }
}
