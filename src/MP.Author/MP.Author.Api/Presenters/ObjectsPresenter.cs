﻿
using MP.Author.Api.Models.Response;
using MP.Author.Api.Serialization;
using MP.Author.Core.Dto.UseCaseResponses;
using MP.Author.Core.Interfaces;
using System.Linq;
using System.Net;

namespace MP.Author.Api.Presenters
{
    public class ObjectsPresenter : IOutputPort<ObjectsDtoResponse>
    {
        public JsonContentResult ContentResult { get; }

        public ObjectsPresenter()
        {
            ContentResult = new JsonContentResult();
        }
        public void Handle(ObjectsDtoResponse response)
        {
            ContentResult.StatusCode = (int)(response.Success ? HttpStatusCode.OK : HttpStatusCode.BadRequest);
            ContentResult.Content = JsonSerializer.SerializeObject(HandleResponse(response));
        }

        private BaseResponse<ObjectsDtoResponse> HandleResponse(ObjectsDtoResponse response)
        {
            var result = new BaseResponse<ObjectsDtoResponse>();

            //result.code = (int)(response.Success ? HttpStatusCode.OK : HttpStatusCode.Unauthorized);
            result.code = response.StatusCode;
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
