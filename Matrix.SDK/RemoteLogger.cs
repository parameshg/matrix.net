using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Matrix.SDK
{
    public class RemoteLogger : RemoteAgent
    {
        public Task Log(Guid applicationId, DateTime timestamp, string source, int level, int @event, string message, Dictionary<string, string> properties = null, List<string> tags = null)
        {
            throw new NotImplementedException();
        }
    }
}