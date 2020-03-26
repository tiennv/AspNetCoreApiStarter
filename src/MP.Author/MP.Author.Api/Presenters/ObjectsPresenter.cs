
using MP.Author.Api.Serialization;
using MP.Author.Core.Dto.UseCaseResponses;
using MP.Author.Core.Interfaces;
using System.Net;

namespace MP.Author.Api.Presenters
{
    public class ObjectsPresenter : IOutputPort<ObjectsResponse>
    {
        public JsonContentResult ContentResult { get; }

        public ObjectsPresenter()
        {
            ContentResult = new JsonContentResult();
        }
        public void Handle(ObjectsResponse response)
        {
            ContentResult.StatusCode = (int)(response.Success ? HttpStatusCode.OK : HttpStatusCode.BadRequest);
            ContentResult.Content = JsonSerializer.SerializeObject(response);
        }
    }
}
