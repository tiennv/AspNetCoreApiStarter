using MP.Author.Core.Dto.UseCaseResponses;
using MP.Author.Core.Interfaces;
using System.Collections.Generic;

namespace MP.Author.Core.Dto.UseCaseRequests
{
    public class ObjectsDtoRequest : IUseCaseRequest<ObjectsDtoResponse>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ParentName { get; set; }
        public string Method { get; set; }
        public bool IsPage { get; set; }
        public string ControllerName { get; set; }
        public string ActionName { get; set; }
        public bool IsApp { get; set; }
        public bool IsShow { get; set; }
        public int ParentId { get; set; }
        public string Route { get; set; }
        public int EnumAction { get; set; }
        public string Icon { get; set; }
        public List<ObjectsDtoRequest> Childrents { get; set; }


        public ObjectsDtoRequest(int id,string name, string parentName, string method, bool isPage, string controllerName, string actionName, string route,
            int enumAction, string icon, bool isShow, bool isApp, int parentId, List<ObjectsDtoRequest> childrents)
        {
            Id = id;
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
