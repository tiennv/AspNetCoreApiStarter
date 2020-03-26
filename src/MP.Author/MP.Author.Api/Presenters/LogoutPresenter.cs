using MP.Author.Api.Interfaces;
using MP.Author.Api.Models.Response;
using MP.Author.Api.Serialization;
using MP.Author.Core.Dto.UseCaseResponses;
using MP.Author.Core.Interfaces;
using System.Net;
using System.Linq;

namespace MP.Author.Api.Presenters
{
    public sealed class LogoutPresenter: IOutputPort<Core.Dto.UseCaseResponses.LogoutResponse>, IBaseResponse<BaseResponse<Models.Response.LogoutResponse>, Core.Dto.UseCaseResponses.LogoutResponse>
    {
        public JsonContentResult ContentResult { get; }

        public LogoutPresenter()
        {
            ContentResult = new JsonContentResult();
        }

        public void Handle(Core.Dto.UseCaseResponses.LogoutResponse response)
        {
            ContentResult.StatusCode = (int)(response.Success ? HttpStatusCode.OK : HttpStatusCode.Unauthorized);
            ContentResult.Content = JsonSerializer.SerializeObject(HandleResponse(response));
            //ContentResult.Content = response.Success ? 
            //    JsonSerializer.SerializeObject(new Models.Response.LogoutResponse(response.Message)), ContentResult.StatusCode.GetValueOrDefault()) : 
            //    JsonSerializer.SerializeObject(response.Errors);
        }


        public BaseResponse<Models.Response.LogoutResponse> HandleResponse(Core.Dto.UseCaseResponses.LogoutResponse response)
        {
            var result = new BaseResponse<Models.Response.LogoutResponse>();

            result.code = (int)(response.Success ? HttpStatusCode.OK : HttpStatusCode.Unauthorized);
            result.msg = response.Errors != null && response.Errors.Count() > 0 ? response.Errors.FirstOrDefault().Description : response.Message;
            result.data = new Models.Response.LogoutResponse(message: response.Message);

            return result;
        }
    }
}
