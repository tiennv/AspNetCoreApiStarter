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

        internal Operations() { /* Required by EF */ }

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
