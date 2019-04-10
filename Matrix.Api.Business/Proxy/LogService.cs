using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using EnsureThat;
using Matrix.Api.Business.Services;
using Matrix.Framework.Business;
using RestSharp;

namespace Matrix.Api.Business.Proxy
{
    public class LogService : Service, ILogService
    {
        private RestClient Api { get; set; }

        public LogService(IServiceContext context)
            : base(context)
        {
            Api = new RestClient(context.Journal);
        }

        public async Task SaveLogEntry(Guid application, string message, DateTime? timestamp = null, string source = null, int level = 0, int @event = 0, Dictionary<string, string> properties = null, List<string> tags = null)
        {
            Ensure.Guid.IsNotEmpty(application);

            Ensure.String.IsNotNullOrEmpty(message);

            if (!timestamp.HasValue)
            {
                timestamp = DateTime.Now;
            }

            var request = new RestRequest("/applications/{application}/logs", Method.POST);

            request.AddUrlSegment("application", application);

            request.AddJsonBody(new
            {
                Application = application,
                Timestamp = timestamp.Value,
                Source = source,
                Level = level,
                Event = @event,
                Message = message,
                Properties = properties,
                Tags = tags
            });

            var response = await Api.ExecuteTaskAsync(request);

            if (!response.StatusCode.Equals(HttpStatusCode.OK))
            {
                throw new ApplicationException(response.StatusDescription);
            }
        }
    }
}