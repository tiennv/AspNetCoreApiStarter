﻿using System;
using System.Collections.Generic;
using System.Text;

namespace MP.Author.Core.Dto
{
    public class MenusDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsShow { get; set; }
        public List<MenuItemDto> MenuItems { get; set; }
    }

    public class MenuItemDto
    {
        public int MenuId { get; set; }
        public int ObjectId { get; set; }
    }
}