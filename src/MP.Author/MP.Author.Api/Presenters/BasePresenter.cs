using MP.Author.Api.Models.Response;
using MP.Author.Api.Serialization;
using MP.Author.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MP.Author.Api.Presenters
{
    public class BasePresenter<T> : IOutputPort<T>
    {
        public JsonContentResult ContentResult { get; }

        public BasePresenter()
        {
            ContentResult = new JsonContentResult();
        }

        public void Handle(T response)
        {            
            ContentResult.Content = JsonSerializer.SerializeObject(HandleResponse(response));
        }

        private BaseResponse<T> HandleResponse(T response)
        {
            var result = new BaseResponse<T>();
            
            if (response != null)
            {
                result.data = response;
            }

            return result;
        }
    }
}
