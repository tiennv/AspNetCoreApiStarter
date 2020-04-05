using MP.Author.Core.Dto.UseCaseResponses;
using MP.Author.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MP.Author.Core.Dto.UseCaseRequests
{
    public class MenusDtoRequest : IUseCaseRequest<MenusDtoResponse>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsShow { get; set; }

        public MenusDtoRequest(int id, string name, bool isShow)
        {
            Id = id;
            Name = name;
            IsShow = isShow;
        }
    }
}
