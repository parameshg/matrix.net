using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Matrix.Agent.Journal.Model;
using Matrix.Framework.Business;

namespace Matrix.Api.Business.Services
{
    public interface ILogService : IService
    {
        Task<List<LogEntry>> GetLogs(Guid application, DateTime from, DateTime to, int page = 1, int count = 10);

        Task<List<LogEntry>> Search(Guid application, DateTime from, DateTime to, string pattern, int page = 1, int count = 10);
    }
}