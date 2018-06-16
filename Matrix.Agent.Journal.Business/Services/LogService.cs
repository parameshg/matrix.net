using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Matrix.Agent.Journal.Database.Repositories;
using Matrix.Agent.Journal.Model;
using Matrix.Framework.Business;

namespace Matrix.Agent.Journal.Business.Services
{
    public class LogService : Service, ILogService
    {
        public ILogRepository Repository { get; }

        public LogService(IServiceContext context, ILogRepository repository)
            : base(context)
        {
            Repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        public async Task<List<LogEntry>> Get(Guid app, DateTime from, DateTime to, int page = 1, int count = 10)
        {
            var result = new List<LogEntry>();

            result.AddRange(await Repository.Get(app, from, to, (page - 1) * count, count));

            return result;
        }

        public async Task<List<LogEntry>> Search(Guid app, DateTime from, DateTime to, string pattern, int page = 1, int count = 10)
        {
            var result = new List<LogEntry>();

            result.AddRange(await Repository.Search(app, from, to, pattern, (page - 1) * count, count));

            return result;
        }

        public async Task<Guid> Save(LogEntry log)
        {
            var result = Guid.Empty;

            result = await Repository.Save(log);

            return result;
        }
    }
}