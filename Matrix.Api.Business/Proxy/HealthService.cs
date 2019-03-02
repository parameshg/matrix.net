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
            Health result = null;

            var api = new RestClient(Context.Configurator);

            var request = new RestRequest("/health", Method.GET);

            var response = await api.ExecuteTaskAsync<Health>(request);

            if (response.StatusCode.Equals(HttpStatusCode.OK))
            {
                result = response.Data;
            }

            return result;
        }

        public async Task<Health> GetDirectoryHealth()
        {
            Health result = null;

            var api = new RestClient(Context.Directory);

            var request = new RestRequest("/health", Method.GET);

            var response = await api.ExecuteTaskAsync<Health>(request);

            if (response.StatusCode.Equals(HttpStatusCode.OK))
            {
                result = response.Data;
            }

            return result;
        }

        public async Task<Health> GetJournalHealth()
        {
            Health result = null;

            var api = new RestClient(Context.Journal);

            var request = new RestRequest("/health", Method.GET);

            var response = await api.ExecuteTaskAsync<Health>(request);

            if (response.StatusCode.Equals(HttpStatusCode.OK))
            {
                result = response.Data;
            }

            return result;
        }

        public async Task<Health> GetPostmanHealth()
        {
            Health result = null;

            var api = new RestClient(Context.Postman);

            var request = new RestRequest("/health", Method.GET);

            var response = await api.ExecuteTaskAsync<Health>(request);

            if (response.StatusCode.Equals(HttpStatusCode.OK))
            {
                result = response.Data;
            }

            return result;
        }

        public async Task<Health> GetRegistryHealth()
        {
            Health result = null;

            var api = new RestClient(Context.Registry);

            var request = new RestRequest("/health", Method.GET);

            var response = await api.ExecuteTaskAsync<Health>(request);

            if (response.StatusCode.Equals(HttpStatusCode.OK))
            {
                result = response.Data;
            }

            return result;
        }
    }
}