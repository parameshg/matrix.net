using System.Collections.Generic;
using Matrix.Framework.Api.Model;

namespace Matrix.Agent.Postman.Model
{
    public class SendSmsRequest : PostRequest
    {
        public List<string> To { get; set; }

        public string Message { get; set; }
    }
}