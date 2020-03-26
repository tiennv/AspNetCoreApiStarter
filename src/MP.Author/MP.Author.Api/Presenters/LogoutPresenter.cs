using MP.Author.Api.Serialization;
using MP.Author.Core.Dto.UseCaseResponses;
using MP.Author.Core.Interfaces;
using System.Net;

namespace MP.Author.Api.Presenters
{
    public sealed class LogoutPresenter: IOutputPort<LogoutResponse>
    {
        public JsonContentResult ContentResult { get; }

        public LogoutPresenter()
        {
            ContentResult = new JsonContentResult();
        }

        public void Handle(LogoutResponse response)
        {
            ContentResult.StatusCode = (int)(response.Success ? HttpStatusCode.OK : HttpStatusCode.Unauthorized);
            ContentResult.Content = response.Success ? JsonSerializer.SerializeObject(new Models.Response.LogoutResponse(response.Message)) : JsonSerializer.SerializeObject(response.Errors);
        }
    }
}
