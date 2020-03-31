using System;
using System.Collections.Generic;

namespace MP.Author.Infrastructure.Models
{
    public partial class Operations
    {
        public Operations()
        {
            Permissions = new HashSet<Permissions>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public bool Create { get; set; }
        public bool Edit { get; set; }
        public bool Delete { get; set; }
        public bool View { get; set; }
        public bool Import { get; set; }
        public bool Export { get; set; }

        public virtual ICollection<Permissions> Permissions { get; set; }
    }
}
