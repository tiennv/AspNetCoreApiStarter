using MP.Author.Api.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MP.Author.Api.Interfaces
{
    interface IBaseResponse<out T, in Z>
    {
        public T HandleResponse(Z response);
    }
}
