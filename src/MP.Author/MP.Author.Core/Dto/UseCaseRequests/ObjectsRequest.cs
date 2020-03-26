using MP.Author.Core.Dto.UseCaseResponses;
using MP.Author.Core.Interfaces;
using System.Collections.Generic;

namespace MP.Author.Core.Dto.UseCaseRequests
{
    public class ObjectsRequest : IUseCaseRequest<ObjectsResponse>
    {
        public string Name { get; }
        public string ParentName { get; }
        public string Method { get; }
        public bool IsPage { get; }
        public string ControllerName { get; }
        public string ActionName { get; }
        public bool IsApp { get; }
        public bool IsShow { get; }
        public int ParentId { get; }
        public string Route { get; }
        public int EnumAction { get; }
        public string Icon { get; }

        public List<ObjectsRequest> Childrents { get; }


        public ObjectsRequest(string name, string parentName, string method, bool isPage, string controllerName, string actionName, string route,
            int enumAction, string icon, bool isShow, bool isApp, int parentId, List<ObjectsRequest> childrents)
        {
            Name = name;
            ParentName = parentName;
            Method = method;
            IsPage = isPage;
            IsApp = isApp;
            IsShow = isShow;
            ControllerName = controllerName;
            ActionName = actionName;
            Route = route;
            EnumAction = enumAction;
            Icon = icon;
            ParentId = parentId;
            Childrents = childrents;
        }
    }
}
