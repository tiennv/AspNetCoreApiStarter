using System;
using System.Collections.Generic;

namespace MP.Author.Infrastructure.Models
{
    public partial class Objects
    {
        public Objects()
        {
            Permissions = new HashSet<Permissions>();
        }

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
        public string EnumAction { get; set; }
        public string Icon { get; set; }

        public virtual ICollection<Permissions> Permissions { get; set; }
    }
}
