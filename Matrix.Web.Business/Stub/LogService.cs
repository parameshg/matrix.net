using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Matrix.Agent.Journal.Model;
using Matrix.Framework.Business;
using Matrix.Web.Business.Services;

namespace Matrix.Web.Business.Stub
{
    public class LogService : Service, ILogService
    {
        public LogService(IServiceContext context)
            : base(context)
        {
        }

        public async Task<List<LogEntry>> GetLogs(Guid application, DateTime from, DateTime to, int page = 1, int count = 10)
        {
            var result = new List<LogEntry>();

            await Task.Run(() =>
            {
                var timestamp = from.AddHours(to.Subtract(from).TotalHours / 2);

                for (int i = 0; i < count; i++)
                {
                    result.Add(new LogEntry()
                    {
                        Id = Guid.NewGuid(),
                        Application = application,
                        Timestamp = timestamp,
                        Event = 100,
                        Level = 1,
                        Source = "virtual",
                        Message = "test log"
                    });
                }
            });

            return result;
        }

        public async Task<List<LogEntry>> Search(Guid application, DateTime from, DateTime to, string pattern, int page = 1, int count = 10)
        {
            var result = new List<LogEntry>();

            await Task.Run(() =>
            {
                var timestamp = from.AddHours(to.Subtract(from).TotalHours / 2);

                for (int i = 0; i < count; i++)
                {
                    result.Add(new LogEntry()
                    {
                        Id = Guid.NewGuid(),
                        Application = application,
                        Timestamp = timestamp,
                        Event = 100,
                        Level = 1,
                        Source = "virtual",
                        Message = $"test {pattern} log"
                    });
                }
            });

            return result;
        }
    }
}