using MP.Author.Core.Shared;

namespace MP.Author.Core.Domain.Entities
{
    public class Objects : BaseEntity
    {
        public string Name { get; private set; }
        public string ParentName { get; private set; }
        public string Method { get; private set; }
        public bool IsPage { get; private set; }
        public string ControllerName { get; private set; }
        public string ActionName { get; private set; }
        public bool IsApp { get; private set; }
        public bool IsShow { get; private set; } 
        public int ParentId { get; private set; }
        public string Route { get; private set; }
        public int EnumAction { get; private set; }
        public string Icon { get; private set; }
        internal Objects() { /* Required by EF */ }
        public Objects(string name, string parentName, string method, bool isPage, string controllerName, string actionName, string route, 
            int enumAction, string icon, bool isShow, bool isApp, int parentId)
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
        }
    }
}
