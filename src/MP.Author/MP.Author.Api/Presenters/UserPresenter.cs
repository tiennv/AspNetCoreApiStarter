using MP.Author.Api.Models.Response;
using MP.Author.Api.Serialization;
using MP.Author.Core.Dto.UseCaseResponses;
using MP.Author.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace MP.Author.Api.Presenters
{
    public class UserPresenter : IOutputPort<UserDtoResponse>
    {
        public JsonContentResult ContentResult { get; }
        public UserPresenter()
        {
            ContentResult = new JsonContentResult();
        }
        public void Handle(UserDtoResponse response)
        {
            ContentResult.StatusCode = (int)(response.Success ? HttpStatusCode.OK : HttpStatusCode.BadRequest);
            ContentResult.Content = JsonSerializer.SerializeObject(HandleResponse(response));
        }

        private BaseResponse<UserDtoResponse> HandleResponse(UserDtoResponse response)
        {
            var result = new BaseResponse<UserDtoResponse>();

            result.code = (int)(response.Success ? HttpStatusCode.OK : HttpStatusCode.Unauthorized);
            result.error = response.Success ? 0 : 1;
            result.msg = response.Message;
            if (response != null && response.Success)
            {
                result.data = response;
            }

            return result;
        }
    }
}
