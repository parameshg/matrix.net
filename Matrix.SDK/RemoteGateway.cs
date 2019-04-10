using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Matrix.SDK
{
    public class RemoteGateway : RemoteAgent
    {
        public Task SendMail(Guid applicationId, string from, string subject, string body, List<string> to, List<string> cc = null, List<string> bcc = null, bool html = true)
        {
            throw new NotImplementedException();
        }

        public Task SendMessage(Guid applicationId, string from, string to, string message)
        {
            throw new NotImplementedException();
        }
    }
}