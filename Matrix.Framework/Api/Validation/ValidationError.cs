using System.Collections.Generic;

namespace Matrix.Framework.Api.Validation
{
    public class ValidationError
    {
        public string Property { get; set; }

        public List<string> Errors { get; set; }

        public ValidationError()
        {
            Errors = new List<string>();
        }
    }
}