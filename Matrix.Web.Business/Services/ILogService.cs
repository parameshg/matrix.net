using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Matrix.Agent.Journal.Model;
using Matrix.Framework.Business;

namespace Matrix.Web.Business.Services
{
    public interface ILogService : IService
    {
        Task<List<LogEntry>> Get(Guid app, DateTime from, DateTime to, int page = 1, int count = 10);

        Task<List<LogEntry>> Search(Guid app, DateTime from, DateTime to, string pattern, int page = 1, int count = 10);
    }
}