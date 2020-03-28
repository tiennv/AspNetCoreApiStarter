using System;
using System.Collections.Generic;
using System.Text;

namespace MP.Author.Core.Interfaces
{
    public abstract class UseCaseResponseMessage
    {
        public bool Success { get; }
        public string Message { get; }
        public int StatusCode { get; set; }

        protected UseCaseResponseMessage(bool success = false, string message = null, int statusCode=200)
        {
            Success = success;
            Message = message;
            StatusCode = statusCode;
        }
    }
}
