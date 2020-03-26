using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MP.Author.Api.Models.Response
{
    public class ObjectsResponse
    {
        public string Message { get; set; }
        public ObjectsResponse(string message)
        {
            Message = message;
        }
    }
}
