using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Matrix.Api.Business.Services;
using Matrix.Framework.Business;

namespace Matrix.Api.Business.Stub
{
    public class LogService : Service, ILogService
    {
        public LogService(IServiceContext context)
            : base(context)
        {
        }

        public Task SaveLogEntry(Guid application, string message, DateTime? timestamp = null, string source = null, int level = 0, int @event = 0, Dictionary<string, string> properties = null, List<string> tags = null)
        {
            throw new NotImplementedException();
        }
    }
}