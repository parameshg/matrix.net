using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Matrix.Agent.Postman.Model;
using Matrix.Api.Business.Services;
using Matrix.Framework.Business;
using RestSharp;

namespace Matrix.Api.Business.Proxy
{
    public class PhoneService : Service, IPhoneService
    {
        private RestClient Api { get; set; }

        public PhoneService(IServiceContext context)
            : base(context)
        {
            Api = new RestClient(Endpoint.Postman);
        }

        public async Task<List<PhoneMessageMetadata>> GetMessages(Guid application, DateTime from, DateTime to, int page = 1, int count = 10)
        {
            var result = new List<PhoneMessageMetadata>();

            await Task.Run(() => { });

            return result;
        }

        public async Task<List<PhoneMessageMetadata>> Search(Guid application, DateTime from, DateTime to, string pattern, int page = 1, int count = 10)
        {
            var result = new List<PhoneMessageMetadata>();

            await Task.Run(() => { });

            return result;
        }

        public async Task<Guid> SendMessage(Guid application, List<string> to, string message)
        {
            var result = Guid.Empty;

            var request = new RestRequest("/applications/{application}/sms", Method.POST);

            request.AddUrlSegment("application", application);

            request.AddJsonBody(new
            {
                application,
                to,
                message
            });

            var response = await Api.ExecuteTaskAsync<Guid>(request);

            if (response.StatusCode.Equals(HttpStatusCode.OK))
                result = response.Data;

            return result;
        }
    }
}