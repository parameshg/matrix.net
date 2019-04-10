using System;
using System.Net;
using System.Threading.Tasks;
using EnsureThat;
using Matrix.Framework.Api.Response;
using Newtonsoft.Json;
using RestSharp;

namespace Matrix.Framework.Business
{
    public class Service : IService
    {
        public IServiceContext Context { get; }

        public Service(IServiceContext context)
        {
            Context = context ?? throw new ArgumentNullException(nameof(context));
        }

        protected async Task<T> Execute<T>(RestClient client, RestRequest request)
        {
            T result = default(T);

            var response = await client.ExecuteTaskAsync(request);

            if (response.StatusCode.Equals(HttpStatusCode.OK))
            {
                var o = JsonConvert.DeserializeObject<ResponseBase>(response.Content);

                if (o.Status)
                {
                    var model = JsonConvert.DeserializeObject<SuccessResponse<T>>(response.Content);

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

        protected void HandleError(IRestResponse response)
        {
            if (!response.StatusCode.Equals(HttpStatusCode.OK))
            {
                if (response.ErrorException != null)
                {
                    throw new ApplicationException(response.ErrorException.Message, response.ErrorException);
                }

                if (!string.IsNullOrEmpty(response.StatusDescription))
                {
                    throw new ApplicationException(response.StatusDescription);
                }

                if (!string.IsNullOrEmpty(response.ErrorMessage))
                {
                    throw new ApplicationException(response.ErrorMessage);
                }
            }
        }
    }
}