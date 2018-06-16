using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Matrix.Agent.Configurator.Database.Repositories;
using Matrix.Framework.Business;

namespace Matrix.Agent.Configurator.Business.Services
{
    public class ConfigurationService : Service, IConfigurationService
    {
        public IConfigurationRepository Repository { get; }

        public ConfigurationService(IServiceContext context, IConfigurationRepository repository)
            : base(context)
        {
            Repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        public async Task<List<KeyValuePair<string, string>>> GetSettings(Guid application)
        {
            var result = new List<KeyValuePair<string, string>>();

            result.AddRange(await Repository.GetSettings(application));

            return result;
        }

        public async Task<string> GetSettings(Guid application, string key)
        {
            var result = string.Empty;

            result = await Repository.GetSettings(application, key);

            return result;
        }

        public async Task<Guid> Create(Guid application, string key, string value)
        {
            var result = Guid.Empty;

            result = await Repository.Create(application, key, value);

            return result;
        }

        public async Task<bool> Update(Guid application, string key, string value)
        {
            var result = false;

            result = await Repository.Update(application, key, value);

            return result;
        }

        public async Task<bool> Delete(Guid application, string key)
        {
            var result = false;

            result = await Repository.Delete(application, key);

            return result;
        }
    }
}