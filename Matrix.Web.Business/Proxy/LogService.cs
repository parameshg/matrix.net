using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Matrix.Agent.Journal.Model;
using Matrix.Framework.Api.Response;
using Matrix.Framework.Business;
using Matrix.Web.Business.Services;
using RestSharp;

namespace Matrix.Web.Business.Proxy
{
    public class LogService : Service, ILogService
    {
        private RestClient Api { get; set; }

        public LogService(IServiceContext context)
            : base(context)
        {
            Api = new RestClient(context.Journal);
        }

        public async Task<List<LogEntry>> GetLogs(Guid application, DateTime from, DateTime to, int page = 1, int count = 10)
        {
            var result = new List<LogEntry>();

            var request = new RestRequest("/applications/{application}/logs/{from}/{to}/{page}/{count}", Method.GET);

            request.AddUrlSegment("application", application);
            request.AddUrlSegment("from", from);
            request.AddUrlSegment("to", to);
            request.AddUrlSegment("page", page);
            request.AddUrlSegment("count", count);

            var response = await Api.ExecuteTaskAsync<SuccessResponse<List<LogEntry>>>(request);

            if (response.StatusCode.Equals(HttpStatusCode.OK))
            {
                result.AddRange(response.Data.Data);
            }

            return result;
        }

        public async Task<List<LogEntry>> Search(Guid application, DateTime from, DateTime to, string pattern, int page = 1, int count = 10)
        {
            var result = new List<LogEntry>();

            var request = new RestRequest("/applications/{application}/logs/{from}/{to}/{page}/{count}", Method.GET);

            request.AddUrlSegment("application", application);
            request.AddUrlSegment("from", from);
            request.AddUrlSegment("to", to);
            request.AddUrlSegment("page", page);
            request.AddUrlSegment("count", count);
            request.AddQueryParameter("q", pattern);

            var response = await Api.ExecuteTaskAsync<List<LogEntry>>(request);

            if (response.StatusCode.Equals(HttpStatusCode.OK))
            {
                result.AddRange(response.Data);
            }

            return result;
        }
    }
}