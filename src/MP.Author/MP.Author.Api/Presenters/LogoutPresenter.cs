using MP.Author.Api.Interfaces;
using MP.Author.Api.Models.Response;
using MP.Author.Api.Serialization;
using MP.Author.Core.Dto.UseCaseResponses;
using MP.Author.Core.Interfaces;
using System.Net;
using System.Linq;

namespace MP.Author.Api.Presenters
{
    public sealed class LogoutPresenter: IOutputPort<LogoutDtoResponse>, IBaseResponse<BaseResponse<LogoutResponse>, LogoutDtoResponse>
    {
        public JsonContentResult ContentResult { get; }

        public LogoutPresenter()
        {
            ContentResult = new JsonContentResult();
        }

        public void Handle(LogoutDtoResponse response)
        {
            ContentResult.StatusCode = (int)(response.Success ? HttpStatusCode.OK : HttpStatusCode.Unauthorized);
            ContentResult.Content = JsonSerializer.SerializeObject(HandleResponse(response));
            //ContentResult.Content = response.Success ? 
            //    JsonSerializer.SerializeObject(new Models.Response.LogoutResponse(response.Message)), ContentResult.StatusCode.GetValueOrDefault()) : 
            //    JsonSerializer.SerializeObject(response.Errors);
        }


        public BaseResponse<LogoutResponse> HandleResponse(LogoutDtoResponse response)
        {
            var result = new BaseResponse<LogoutResponse>();

            result.code = (int)(response.Success ? HttpStatusCode.OK : HttpStatusCode.Unauthorized);
            result.error = response.Success ? 0 : 1;
            result.msg = response.Errors != null && response.Errors.Count() > 0 ? response.Errors.FirstOrDefault().Description : response.Message;
            if (response != null && response.Success)
            {
                result.data = new LogoutResponse(message: response.Message);
            }

            return result;
        }
    }
}
