using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MP.Author.Api.Models.Response
{
    public class LogoutResponse
    {
        public string Message { get; set; }
        public LogoutResponse(string message)
        {
            Message = message;
        }
    }
}
