using MP.Author.Api.Models.Response;
using MP.Author.Api.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace MP.Author.Api.Presenters
{
    public class ErorrPresenter
    {
        public string ErorrResult { get; }        
        public ErorrPresenter(Exception exception)
        {
            ErorrResult = JsonSerializer.SerializeObject(HandleResponse(exception));
        }       

        private BaseResponse<object> HandleResponse(Exception response)
        {
            var result = new BaseResponse<object>();

            result.code = (int)HttpStatusCode.InternalServerError;
            result.error = 1;
            result.msg = response.Message;
            result.data = response.InnerException?.Message;

            return result;
        }
    }
}
