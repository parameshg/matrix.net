using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Matrix.Agent.Postman.Model;
using Matrix.Framework.Business;
using Matrix.Web.Business.Services;
using RestSharp;

namespace Matrix.Web.Business.Proxy
{
    public class EmailService : Service, IEmailService
    {
        private RestClient Api { get; set; }

        public EmailService(IServiceContext context)
            : base(context)
        {
            Api = new RestClient(context.Postman);
        }

        public async Task<List<EmailMetadata>> GetEmails(Guid application, DateTime from, DateTime to, int page = 1, int count = 10)
        {
            var result = new List<EmailMetadata>();

            await Task.Run(() => { });

            return result;
        }

        public async Task<List<EmailMetadata>> Search(Guid application, DateTime from, DateTime to, string pattern, int page = 1, int count = 10)
        {
            var result = new List<EmailMetadata>();

            await Task.Run(() => { });

            return result;
        }

        public async Task<Guid> SendMail(Guid application, List<string> to, List<string> cc, List<string> bcc, string subject, string body, bool html)
        {
            var result = Guid.Empty;

            var request = new RestRequest("/applications/{application}/mail", Method.POST);

            request.AddUrlSegment("application", application);

            request.AddJsonBody(new
            {
                application,
                to,
                cc,
                bcc,
                subject,
                body,
                html
            });

            var response = await Api.ExecuteTaskAsync<Guid>(request);

            if (response.StatusCode.Equals(HttpStatusCode.OK))
            {
                result = response.Data;
            }

            return result;
        }
    }
}