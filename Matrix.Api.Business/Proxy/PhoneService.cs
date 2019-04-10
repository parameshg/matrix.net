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
    public class PhoneService : Service, IPhoneService
    {
        private RestClient Api { get; set; }

        public PhoneService(IServiceContext context)
            : base(context)
        {
            Api = new RestClient(context.Postman);
        }

        public async Task<Guid> SendText(Guid application, List<string> to, string message)
        {
            var result = Guid.Empty;

            Ensure.Guid.IsNotEmpty(application);

            Ensure.Any.IsNotNull(to);

            Ensure.Bool.IsTrue(to.Count > 0);

            Ensure.String.IsNotNullOrEmpty(message);

            var request = new RestRequest("/applications/{application}/sms", Method.POST);

            request.AddUrlSegment("application", application);

            request.AddJsonBody(new
            {
                application,
                to,
                message
            });

            var response = await Api.ExecuteTaskAsync(request);

            if (response.StatusCode.Equals(HttpStatusCode.OK))
            {
                var o = JsonConvert.DeserializeObject<ResponseBase>(response.Content);

                if (o.Status)
                {
                    var model = JsonConvert.DeserializeObject<SuccessResponse<Guid>>(response.Content);

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