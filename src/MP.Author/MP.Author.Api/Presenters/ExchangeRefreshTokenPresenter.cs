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
    public sealed class ExchangeRefreshTokenPresenter : IOutputPort<ExchangeRefreshTokenResponse>
    {
        public JsonContentResult ContentResult { get; }

        public ExchangeRefreshTokenPresenter()
        {
            ContentResult = new JsonContentResult();
        }

        public void Handle(ExchangeRefreshTokenResponse response)
        {
            ContentResult.StatusCode = (int)(response.Success ? HttpStatusCode.OK : HttpStatusCode.BadRequest);
            ContentResult.Content = response.Success ? JsonSerializer.SerializeObject(new Models.Response.ExchangeRefreshTokenResponse(response.AccessToken, response.RefreshToken)) : JsonSerializer.SerializeObject(response.Message);
        }
    }
}
