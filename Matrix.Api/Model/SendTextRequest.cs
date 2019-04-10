using System.Collections.Generic;
using Matrix.Framework.Api.Model;

namespace Matrix.Api.Model
{
    public class SendTextRequest : PostRequest
    {
        public List<string> To { get; set; }

        public string Message { get; set; }
    }
}