using MP.Author.Core.Shared;
using System;
using System.Collections.Generic;
using System.Text;

namespace MP.Author.Core.Domain.Entities
{
    public class Operations : BaseEntity
    {
        public string Name { get; set; }
        public bool Create { get; set; }
        public bool Edit { get; set; }
        public bool Delete { get; set; }
        public bool View { get; set; }
        public bool Import { get; set; }
        public bool Export { get; set; }

        public virtual ICollection<Permissions> Permissions { get; set; }

        internal Operations() {
            Permissions = new HashSet<Permissions>();
        }

        internal Operations(string name, bool create, bool edit, bool delete, bool view, bool import, bool export) {
            Name = name;
            Create = create;
            Edit = edit;
            Delete = delete;
            View = view;
            Import = import;
            Export = export;
        }
    }
}
