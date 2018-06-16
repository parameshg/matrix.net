using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Matrix.Agent.Postman.Database.Repositories;
using Matrix.Framework.Api.Response;
using Matrix.Framework.Business;
using Newtonsoft.Json;
using RestSharp;

namespace Matrix.Agent.Postman.Business.Services
{
    public class EmailService : Service, IEmailService
    {
        private IEmailRepository Repository { get; }

        private ISendMailService Mailer { get; set; }

        public EmailService(IServiceContext context, ISendMailService mailer, IEmailRepository repository)
            : base(context)
        {
            Mailer = mailer ?? throw new ArgumentNullException(nameof(mailer));

            Repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        public async Task<Guid> SendMail(Guid application, List<string> to, List<string> cc, List<string> bcc, string subject, string body, bool html)
        {
            var result = Guid.Empty;

            var from = await GetConfiguration(application, "mail.from");

            result = await Repository.CreateEmail(application, from, to, cc, bcc, subject, body, html, 0);

            return result;
        }

        private async Task<string> GetConfiguration(Guid application, string key)
        {
            return await GetConfiguration<string>(application, key);
        }

        private async Task<T> GetConfiguration<T>(Guid application, string key)
        {
            T result = default(T);

            var web = new RestClient($"http://configuration/api/applications/{application}");

            var response = await web.ExecuteGetTaskAsync<string>(new RestRequest($"/{key}"));

            if (response.ResponseStatus == ResponseStatus.Completed && response.StatusCode == HttpStatusCode.OK)
            {
                var json = JsonConvert.DeserializeObject<SuccessResponse>(response.Content);

                if (json != null)
                    result = (T)json.Data;
            }

            return result;
        }
    }
}