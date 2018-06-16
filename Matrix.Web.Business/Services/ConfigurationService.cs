using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Matrix.Framework.Business;

namespace Matrix.Web.Business.Services
{
    public class ConfigurationService : Service, IConfigurationService
    {
        public ConfigurationService(IServiceContext context)
            : base(context)
        {
        }

        public Task<List<KeyValuePair<string, string>>> GetSettings(Guid application)
        {
            throw new NotImplementedException();
        }

        public Task<string> GetSettings(Guid application, string key)
        {
            throw new NotImplementedException();
        }

        public Task<Guid> Create(Guid application, string key, string value)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Update(Guid application, string key, string value)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Delete(Guid application, string key)
        {
            throw new NotImplementedException();
        }
    }
}