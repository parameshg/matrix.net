using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Matrix.Agent.Postman.Database.Repositories;
using Matrix.Framework.Api.Response;
using Matrix.Framework.Business;
using Matrix.Framework.Configuration;
using Matrix.Framework.Constants;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using RestSharp;

namespace Matrix.Agent.Postman.Business.Services
{
    public class MailService : Service, IMailService
    {
        private IMailRepository Repository { get; }

        private IConfiguration Configuration { get; }

        private ISendMailService Mailer { get; set; }

        public MailService(IConfiguration configuration, IServiceContext context, ISendMailService mailer, IMailRepository repository)
            : base(context)
        {
            Configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));

            Mailer = mailer ?? throw new ArgumentNullException(nameof(mailer));

            Repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        public async Task<Guid> SendMail(Guid application, List<string> to, List<string> cc, List<string> bcc, string subject, string body, bool html)
        {
            var result = Guid.Empty;

            var from = await GetConfiguration(application, "mail.from");

            if (string.IsNullOrEmpty(from))
            {
                from = await GetConfiguration(This.Id, "mail.from");
            }

            if (string.IsNullOrEmpty(from))
            {
                from = "matrix@paramg.com";
            }

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

            var configuration = Configuration.GetSection(GlobalConfiguration.Root).Get<GlobalConfiguration>();

            var endpoint = configuration?.Endpoints?.Configurator;

            if (endpoint != null)
            {
                var api = new RestClient(endpoint);

                var response = await api.ExecuteTaskAsync(new RestRequest($"/applications/{application}/configuration/{Convert.ToBase64String(Encoding.ASCII.GetBytes(key))}", Method.GET));

                if (response.StatusCode == HttpStatusCode.OK)
                {
                    var o = JsonConvert.DeserializeObject<SuccessResponse<T>>(response.Content);

                    if (o != null)
                    {
                        result = o.Data;
                    }
                }
            }

            return result;
        }
    }
}