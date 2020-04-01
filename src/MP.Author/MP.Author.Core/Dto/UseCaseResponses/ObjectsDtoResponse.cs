using MP.Author.Core.Domain.Entities;
using MP.Author.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MP.Author.Core.Dto.UseCaseResponses
{
    public class ObjectsDtoResponse : UseCaseResponseMessage
    {
        public IEnumerable<Error> Errors { get; }
        public List<ObjectDto> Objects { get; set; }
        public ObjectDto Object { get; set; }
        public ObjectsDtoResponse(IEnumerable<Error> errors, bool success = false, string message = null) : base(success, message)
        {
            Errors = errors;
        }

        public ObjectsDtoResponse(bool success = false, string message = null) : base(success, message)
        {

        }

        public ObjectsDtoResponse(List<ObjectDto> objects = null, bool success = false, string message = null) : base(success, message)
        {
            Objects = objects;
        }

        public ObjectsDtoResponse(ObjectDto objects = null, bool success = false, string message = null) : base(success, message)
        {
            Object = objects;
        }
    }
}
