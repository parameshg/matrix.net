using System;

namespace Matrix.Framework.Api.Validation
{
    public class ValidationException : Exception
    {
        public ValidationErrorResponse Response { get; private set; }

        public ValidationException(ValidationErrorResponse response)
            : base("validation error")
        {
            Response = response;
        }
    }
}