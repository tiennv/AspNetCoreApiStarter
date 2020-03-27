using MP.Author.Core.Dto.UseCaseResponses;
using MP.Author.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MP.Author.Core.Dto.UseCaseRequests
{
    public class OperationsDtoRequest : IUseCaseRequest<OperationsDtoResponse>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool Create { get; set; }
        public bool Edit { get; set; }
        public bool Delete { get; set; }
        public bool View { get; set; }
        public bool Import { get; set; }
        public bool Export { get; set; }
    }
}
