using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MP.Author.Api.Models.Request
{
    public class MenusRequest
    {
        public int Id { get; set; }        
        public string Name { get; set; }
        public bool IsShow { get; set; }
    }

    public class MenuItemsRequest
    {
        public int MenuId { get; set; }
        public int ObjectId { get; set; }

    }
}
