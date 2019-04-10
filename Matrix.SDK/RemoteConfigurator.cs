using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RestSharp;

namespace Matrix.SDK
{
    public class RemoteConfigurator : RemoteAgent
    {
        public async Task<string> GetSettings(Guid applicationId, string key)
        {
            var result = string.Empty;

            var config = await Api.GetAsync<List<KeyValuePair<string, string>>>(new RestRequest($"/applications/{applicationId}/configuration"));

            if (config is List<KeyValuePair<string, string>>)
            {
                result = config.FirstOrDefault(i => i.Key == key).Value;
            }

            return result;
        }
    }
}