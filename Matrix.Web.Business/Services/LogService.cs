using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Matrix.Agent.Journal.Model;
using Matrix.Framework.Business;

namespace Matrix.Web.Business.Services
{
    public class LogService : Service, ILogService
    {
        public LogService(IServiceContext context)
            : base(context)
        {
        }

        public Task<List<LogEntry>> Get(Guid app, DateTime from, DateTime to, int page = 1, int count = 10)
        {
            throw new NotImplementedException();
        }

        public Task<List<LogEntry>> Search(Guid app, DateTime from, DateTime to, string pattern, int page = 1, int count = 10)
        {
            throw new NotImplementedException();
        }
    }
}