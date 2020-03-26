using MP.Author.Api.Models.Response;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace MP.Author.Api.Serialization
{
    public sealed class JsonSerializer
    {
        private static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            ContractResolver = new JsonContractResolver(),
            NullValueHandling = NullValueHandling.Ignore
        };

        public static string SerializeObject(object o)
        {
            return JsonConvert.SerializeObject(o, Formatting.Indented, Settings);
        }

        public sealed class JsonContractResolver : CamelCasePropertyNamesContractResolver
        {
        }
    }

    public interface IBaseResponseSerializer<T>
    {
        BaseResponse<T> BaseResponse();
    }

    public class BaseResponseSerializer : IBaseResponseSerializer<LoginResponse>
    {
        public BaseResponse<LoginResponse> BaseResponse()
        {
            throw new System.NotImplementedException();
        }
    }
}
