using MP.Author.Core.Dto.UseCaseResponses;
using MP.Author.Core.Interfaces;

namespace MP.Author.Core.Dto.UseCaseRequests
{
    public class ValidationPermissionDtoRequest : IUseCaseRequest<ValidationPermissionDtoResponse>
    {
        public string Route { get; set; }
        public string ControllerName { get; set; }
        public string ActionName { get; set; }
        public string AccessToken { get; set; }
        public string SigningKey { get; set; }

        public ValidationPermissionDtoRequest(string router, string controllerName, string actionName, string accsessToken, string signingKey)
        {
            Route = router;
            ControllerName = controllerName;
            ActionName = actionName;
            AccessToken = accsessToken;
            SigningKey = signingKey;
        }
    }
}
