using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MP.Author.Api.Models.Response
{
    public class BaseResponse<T>
    {
        public int error { get; set; }
        public string msg { get; set; }
        public int code { get; set; }
        public T data { get; set; }
    }
}
