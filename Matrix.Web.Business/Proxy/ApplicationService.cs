using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Matrix.Agent.Registry.Model;
using Matrix.Framework.Api.Response;
using Matrix.Framework.Business;
using Matrix.Web.Business.Services;
using RestSharp;

namespace Matrix.Web.Business.Proxy
{
    public class ApplicationService : Service, IApplicationService
    {
        private RestClient Api { get; set; }

        public ApplicationService(IServiceContext context)
            : base(context)
        {
            Api = new RestClient(context.Registry);
        }

        public async Task<List<Application>> GetApplications()
        {
            var result = new List<Application>();

            var request = new RestRequest("/applications", Method.GET);

            var response = await Api.ExecuteTaskAsync<ResponseBase>(request);

            if (response.StatusCode.Equals(HttpStatusCode.OK))
            {
                if (response != null && response.Data != null)
                {
                    if (response.Data.Status)
                    {
                        //result.AddRange((response.Data as SuccessResponse).Data as List<Application>);
                    }
                }
            }

            return result;
        }

        public async Task<Guid> Register(string name, string description)
        {
            var result = Guid.Empty;

            var request = new RestRequest("/applications", Method.POST);

            request.AddJsonBody(new
            {
                name,
                description
            });

            var response = await Api.ExecuteTaskAsync<Guid>(request);

            if (response.StatusCode.Equals(HttpStatusCode.OK))
            {
                result = response.Data;
            }

            return result;
        }

        public async Task<bool> Update(Guid id, string name, string description)
        {
            var result = false;

            var request = new RestRequest("/applications", Method.PUT);

            request.AddJsonBody(new
            {
                id,
                name,
                description
            });

            var response = await Api.ExecuteTaskAsync<bool>(request);

            if (response.StatusCode.Equals(HttpStatusCode.OK))
            {
                result = response.Data;
            }

            return result;
        }

        public async Task<bool> Delete(Guid id)
        {
            var result = false;

            var request = new RestRequest("/applications/{id}", Method.DELETE);

            request.AddUrlSegment("id", id.ToString());

            var response = await Api.ExecuteTaskAsync<bool>(request);

            if (response.StatusCode.Equals(HttpStatusCode.OK))
            {
                result = response.Data;
            }

            return result;
        }
    }
}