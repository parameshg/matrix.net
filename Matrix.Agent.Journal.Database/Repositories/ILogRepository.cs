using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Matrix.Agent.Journal.Model;
using Matrix.Framework.Database;

namespace Matrix.Agent.Journal.Database.Repositories
{
    public interface ILogRepository : IRepository
    {
        Task<List<LogEntry>> Get(Guid app, DateTime from, DateTime to, int skip = 0, int count = 10);

        Task<List<LogEntry>> Search(Guid app, DateTime from, DateTime to, string pattern, int skip = 0, int count = 10);

        Task<Guid> Save(LogEntry log);
    }
}