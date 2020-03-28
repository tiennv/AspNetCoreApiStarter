using MP.Author.Api.Interfaces;
using MP.Author.Api.Models.Response;
using MP.Author.Api.Serialization;
using MP.Author.Core.Dto.UseCaseResponses;
using MP.Author.Core.Interfaces;
using System.Linq;
using System.Net;

namespace MP.Author.Api.Presenters
{
    public sealed class LoginPresenter : IOutputPort<LoginDtoResponse>, IBaseResponse<BaseResponse<LoginResponse>, LoginDtoResponse>
    {
        public JsonContentResult ContentResult { get; }

        public LoginPresenter()
        {
            ContentResult = new JsonContentResult();
        }

        public void Handle(LoginDtoResponse response)
        {
            ContentResult.StatusCode = (int)(response.Success ? HttpStatusCode.OK : HttpStatusCode.Unauthorized);
            ContentResult.Content = JsonSerializer.SerializeObject(HandleResponse(response));
            // TODO: cho nay
            /*var objResponse = new Models.Response.BaseResponse<Models.Response.LoginResponse>();
            objResponse.data = new Models.Response.LoginResponse(response.AccessToken, response.RefreshToken);
            ContentResult.Content = response.Success ? JsonSerializer.SerializeObject(objResponse) : JsonSerializer.SerializeObject(response.Errors);*/
            //ContentResult.Content = response.Success ? JsonSerializer.SerializeObject(new Models.Response.LoginResponse(response.AccessToken, response.RefreshToken)) : JsonSerializer.SerializeObject(response.Errors);
        }

        public BaseResponse<LoginResponse> HandleResponse(LoginDtoResponse response)
        {
            var result = new BaseResponse<LoginResponse>();
            result.code = (int)(response.Success ? HttpStatusCode.OK : HttpStatusCode.Unauthorized);
            result.error = response.Success ? 0 : 1;
            result.msg = response.Errors != null && response.Errors.Count() > 0 ? response.Errors.FirstOrDefault().Description : response.Message;
            if (response.Success)
            {
                result.data = new LoginResponse(response.AccessToken, response.Roles, response.RefreshToken);
            }


            return result;
        }
    }
}
