using MP.Author.Core.Shared;
using System;
using System.Collections.Generic;
using System.Text;

namespace MP.Author.Core.Domain.Entities
{
    public class Menus : BaseEntity
    {
        public string Name { get; set; }
        public bool IsShow { get; set; }
        public string Url { get; set; }
        public int Order { get; set; }
    }

    public class MenuItems : BaseEntity
    {
        public int MenuId { get; set; }
        public int ObjectId { get; set; }
    }

}
