using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Matrix.Agent.Postman.Business.Services;
using Matrix.Agent.Postman.Database.Repositories;
using Matrix.Framework.Api.Response;
using Newtonsoft.Json;
using Quartz;
using RestSharp;

namespace Matrix.Agent.Postman.Business.Jobs
{
    public class EmailJob : IJob
    {
        private IEmailRepository Repository { get; }

        private ISendMailService Server { get; set; }

        public EmailJob(ISendMailService service, IEmailRepository repository)
        {
            Server = service ?? throw new ArgumentNullException(nameof(service));

            Repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        public async Task Execute(IJobExecutionContext context)
        {
            var apps = new List<Guid>();

            apps.ForEach(async application =>
            {
                var mails = await Repository.GetEmailWithStatus(application, 0);

                mails.ForEach(async mail =>
                {
                    var host = await GetConfiguration(application, "mail.host");
                    var port = await GetConfiguration<int>(application, "mail.port");
                    var username = await GetConfiguration(application, "mail.username");
                    var password = await GetConfiguration(application, "mail.password");

                    var status = await Server.Execute(host, port, username, password, mail.From, mail.To, mail.Cc, mail.Bcc, mail.Subject, mail.Body, mail.HTML) ? 1 : -1;

                    await Repository.UpdateEmail(mail.Id, status);
                });
            });
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