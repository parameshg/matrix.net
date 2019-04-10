using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using EnsureThat;
using Matrix.Agent.Registry.Model;
using Matrix.Api.Business.Services;
using Matrix.Framework.Api.Response;
using Matrix.Framework.Business;
using Newtonsoft.Json;
using RestSharp;

namespace Matrix.Api.Business.Proxy
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

            var response = await Api.ExecuteTaskAsync(request);

            if (response.StatusCode.Equals(HttpStatusCode.OK))
            {
                Ensure.String.IsNotNullOrEmpty(response.Content);

                var o = JsonConvert.DeserializeObject<ResponseBase>(response.Content);

                if (o.Status)
                {
                    var model = JsonConvert.DeserializeObject<SuccessResponse<IEnumerable<Application>>>(response.Content);

                    Ensure.Any.IsNotNull(model, "SuccessResponse", i => i.WithMessage("Cannot deserialize success response"));

                    result.AddRange(model.Data);
                }
                else
                {
                    var model = JsonConvert.DeserializeObject<ErrorResponse>(response.Content);

                    Ensure.Any.IsNotNull(model, "ErrorReponse", i => i.WithMessage("Cannot deserialize error response"));

                    throw new ApplicationException(model.Error);
                }
            }
            else
            {
                HandleError(response);
            }

            return result;
        }

        public async Task<bool> Login(Guid application)
        {
            var result = false;

            Ensure.Guid.IsNotEmpty(application);

            var applications = await GetApplications();

            result = applications.Count(i => i.Id.Equals(application)).Equals(1);

            return result;
        }

        public async Task<bool> Logout(Guid application)
        {
            var result = false;

            Ensure.Guid.IsNotEmpty(application);

            var applications = await GetApplications();

            result = applications.Count(i => i.Id.Equals(application)).Equals(1);

            return result;
        }
    }
}