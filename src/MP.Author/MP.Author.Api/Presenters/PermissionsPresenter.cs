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
    public class PermissionsPresenter : IOutputPort<PermissionsDtoResponse>
    {
        public JsonContentResult ContentResult { get; }
        public PermissionsPresenter()
        {
            ContentResult = new JsonContentResult();
        }

        public void Handle(PermissionsDtoResponse response)
        {
            ContentResult.StatusCode = (int)(response.Success ? HttpStatusCode.OK : HttpStatusCode.BadRequest);
            ContentResult.Content = JsonSerializer.SerializeObject(HandleResponse(response));
        }

        private BaseResponse<PermissionsDtoResponse> HandleResponse(PermissionsDtoResponse response)
        {
            var result = new BaseResponse<PermissionsDtoResponse>();

            result.code = (int)(response.Success ? HttpStatusCode.OK : HttpStatusCode.Unauthorized);
            result.error = response.Success ? 0 : 1;
            result.msg = response.Errors != null && response.Errors.Count() > 0 ? response.Errors.FirstOrDefault().Description : response.Message;
            if (response != null && response.Success)
            {
                result.data = response;
            }

            return result;
        }
    }
}
