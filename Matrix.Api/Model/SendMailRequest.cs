using System.Collections.Generic;
using Matrix.Framework.Api.Model;

namespace Matrix.Api.Model
{
    public class SendMailRequest : PostRequest
    {
        public List<string> To { get; set; }

        public List<string> Cc { get; set; }

        public List<string> Bcc { get; set; }

        public string Subject { get; set; }

        public string Body { get; set; }

        public bool HTML { get; set; }
    }
}