using System;
using System.Collections.Generic;
using System.Text;

namespace MP.Author.Core.Dto
{
    public class BaseDtoResponse<T>
    {
        public int error { get; set; }
        public string msg { get; set; }
        public int code { get; set; }
        public T data { get; set; }
    }
}
