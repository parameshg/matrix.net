using System.Collections.Generic;

namespace Matrix.Framework.Api.Validation
{
    public class ValidationErrorResponse
    {
        public string Method { get; set; }

        public List<ValidationError> Errors { get; set; }
    }
}