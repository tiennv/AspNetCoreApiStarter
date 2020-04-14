using MP.Author.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MP.Author.Core.Dto.UseCaseResponses
{
    public class ValidationPermissionDtoResponse : UseCaseResponseMessage
    {
        public List<ObjectDto> Objects { get; }
        public ObjectDto Object { get; }
        public Error Error { get; }
        public ValidationPermissionDtoResponse(List<ObjectDto> objects, bool success = false, string message = null) : base(success, message)
        {
            Objects = objects;
        }

        public ValidationPermissionDtoResponse(ObjectDto objectDto, bool success = false, string message = null) : base(success, message)
        {
            Object = objectDto;
        }

        public ValidationPermissionDtoResponse(Error error, ObjectDto objectDto, bool success = false, string message = null) : base(success, message)
        {
            Object = objectDto;
            Error = error;
        }
    }
}
