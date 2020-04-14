using MP.Author.Api.Models.Response;
using MP.Author.Api.Serialization;
using MP.Author.Core.Dto.UseCaseResponses;
using MP.Author.Core.Interfaces;
using System.Net;

namespace MP.Author.Api.Presenters
{
    public class ValidationPermissionPresenter : IOutputPort<ValidationPermissionDtoResponse>
    {
        public JsonContentResult ContentResult { get; }
        public ValidationPermissionPresenter()
        {
            ContentResult = new JsonContentResult();
        }
        public void Handle(ValidationPermissionDtoResponse response)
        {
            ContentResult.StatusCode = (int)(response.Success ? HttpStatusCode.OK : HttpStatusCode.BadRequest);
            ContentResult.Content = JsonSerializer.SerializeObject(HandleResponse(response));
        }

        private BaseResponse<ValidationPermissionDtoResponse> HandleResponse(ValidationPermissionDtoResponse response)
        {
            var result = new BaseResponse<ValidationPermissionDtoResponse>();

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
