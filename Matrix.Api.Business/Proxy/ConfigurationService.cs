using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using EnsureThat;
using Matrix.Api.Business.Services;
using Matrix.Framework.Api.Response;
using Matrix.Framework.Business;
using Newtonsoft.Json;
using RestSharp;

namespace Matrix.Api.Business.Proxy
{
    public class ConfigurationService : Service, IConfigurationService
    {
        private RestClient Api { get; set; }

        public ConfigurationService(IServiceContext context)
            : base(context)
        {
            Api = new RestClient(context.Configurator);
        }

        public async Task<List<KeyValuePair<string, string>>> GetSettings(Guid application)
        {
            var result = new List<KeyValuePair<string, string>>();

            Ensure.Guid.IsNotEmpty(application);

            var request = new RestRequest("/applications/{application}/configuration", Method.GET);

            request.AddUrlSegment("application", application);

            var response = await Api.ExecuteTaskAsync(request);

            if (response.StatusCode.Equals(HttpStatusCode.OK))
            {
                Ensure.String.IsNotNullOrEmpty(response.Content);

                var o = JsonConvert.DeserializeObject<ResponseBase>(response.Content);

                if (o.Status)
                {
                    var model = JsonConvert.DeserializeObject<SuccessResponse<List<KeyValuePair<string, string>>>>(response.Content);

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

            return result;
        }

        public async Task<string> GetSettings(Guid application, string key)
        {
            var result = string.Empty;

            Ensure.Guid.IsNotEmpty(application);

            Ensure.String.IsNotNullOrEmpty(key);

            var request = new RestRequest("/applications/{application}/configuration/{key}", Method.GET);

            request.AddUrlSegment("application", application);

            request.AddUrlSegment("key", key);

            var response = await Api.ExecuteTaskAsync(request);

            if (response.StatusCode.Equals(HttpStatusCode.OK))
            {
                var o = JsonConvert.DeserializeObject<ResponseBase>(response.Content);

                if (o.Status)
                {
                    var model = JsonConvert.DeserializeObject<SuccessResponse<string>>(response.Content);

                    Ensure.Any.IsNotNull(model, "SuccessResponse", i => i.WithMessage("Cannot deserialize success response"));

                    result = model.Data;
                }
                else
                {
                    var model = JsonConvert.DeserializeObject<ErrorResponse>(response.Content);

                    Ensure.Any.IsNotNull(model, "ErrorReponse", i => i.WithMessage("Cannot deserialize error response"));

                    throw new ApplicationException(model.Error);
                }
            }

            return result;
        }
    }
}