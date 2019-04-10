using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Matrix.Framework;
using Matrix.Framework.Business;
using RestSharp;

namespace Matrix.Api.Business.Proxy
{
    public class HealthService : Service, Services.IHealthService
    {
        public HealthService(IServiceContext context)
            : base(context)
        {
        }

        public async Task<Health> GetConfiguratorHealth()
        {
            var result = new Health();

            var api = new RestClient(Context.Configurator);

            var request = new RestRequest("/health", Method.GET);

            var response = await api.ExecuteTaskAsync<Health>(request);

            if (response.StatusCode.Equals(HttpStatusCode.OK))
            {
                result = response.Data;
            }
            else
            {
                result.Errors.AddRange(GetErrorMessages(response));
            }

            return result;
        }

        public async Task<Health> GetDirectoryHealth()
        {
            var result = new Health();

            var api = new RestClient(Context.Directory);

            var request = new RestRequest("/health", Method.GET);

            var response = await api.ExecuteTaskAsync<Health>(request);

            if (response.StatusCode.Equals(HttpStatusCode.OK))
            {
                result = response.Data;
            }
            else
            {
                result.Errors.AddRange(GetErrorMessages(response));
            }

            return result;
        }

        public async Task<Health> GetJournalHealth()
        {
            var result = new Health();

            var api = new RestClient(Context.Journal);

            var request = new RestRequest("/health", Method.GET);

            var response = await api.ExecuteTaskAsync<Health>(request);

            if (response.StatusCode.Equals(HttpStatusCode.OK))
            {
                result = response.Data;
            }
            else
            {
                result.Errors.AddRange(GetErrorMessages(response));
            }

            return result;
        }

        public async Task<Health> GetPostmanHealth()
        {
            var result = new Health();

            var api = new RestClient(Context.Postman);

            var request = new RestRequest("/health", Method.GET);

            var response = await api.ExecuteTaskAsync<Health>(request);

            if (response.StatusCode.Equals(HttpStatusCode.OK))
            {
                result = response.Data;
            }
            else
            {
                result.Errors.AddRange(GetErrorMessages(response));
            }

            return result;
        }

        public async Task<Health> GetRegistryHealth()
        {
            var result = new Health();

            var api = new RestClient(Context.Registry);

            var request = new RestRequest("/health", Method.GET);

            var response = await api.ExecuteTaskAsync<Health>(request);

            if (response.StatusCode.Equals(HttpStatusCode.OK))
            {
                result = response.Data;
            }
            else
            {
                result.Errors.AddRange(GetErrorMessages(response));
            }

            return result;
        }

        private IEnumerable<string> GetErrorMessages(IRestResponse<Health> response)
        {
            var result = new List<string>();

            if (!string.IsNullOrEmpty(response.StatusDescription))
            {
                result.Add(response.StatusDescription);
            }

            if (!string.IsNullOrEmpty(response.ErrorMessage))
            {
                result.Add(response.ErrorMessage);
            }

            if (response.ErrorException != null)
            {
                result.Add(response.ErrorException.ToString());
            }

            return result;
        }
    }
}