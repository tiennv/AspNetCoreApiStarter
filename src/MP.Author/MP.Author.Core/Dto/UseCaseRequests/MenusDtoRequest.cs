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
        public string Url { get; set; }
        public int Order { get; set; }

        public MenusDtoRequest(int id, string name, int order = 0, bool isShow=false, string url = null)
        {
            Id = id;
            Name = name;
            IsShow = isShow;
            Url = url;
            Order = order;
        }
    }
}
