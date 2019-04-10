using System;
using RestSharp;

namespace Matrix.SDK
{
    public abstract class RemoteAgent
    {
        protected IRestClient Api
        {
            get
            {
                IRestClient result = null;

                var endpoint = Environment.GetEnvironmentVariable("MATRIX");

                if (string.IsNullOrEmpty(endpoint))
                {
                    result = new RestClient("http://api.matrix.paramg.com");
                }
                else
                {
                    result = new RestClient(endpoint);
                }

                return result;
            }
        }
    }
}