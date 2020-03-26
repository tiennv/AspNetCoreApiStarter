using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MP.Author.Api.Models.Request
{
    public class ObjectsRequest
    {        
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

        public List<ObjectsRequest> Childrents { get; set; }
    }
}
