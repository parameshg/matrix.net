using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Matrix.Api.Business.Services;
using Matrix.Framework.Business;
using Matrix.Framework.Constants;

namespace Matrix.Api.Business.Stub
{
    public class ConfigurationService : Service, IConfigurationService
    {
        private Dictionary<Guid, List<KeyValuePair<string, string>>> db { get; set; }

        public ConfigurationService(IServiceContext context)
            : base(context)
        {
            db = new Dictionary<Guid, List<KeyValuePair<string, string>>>();

            db.Add(This.Id, new List<KeyValuePair<string, string>>());

            db[This.Id].Add(new KeyValuePair<string, string>("system.version", "1.0"));
        }

        public async Task<List<KeyValuePair<string, string>>> GetSettings(Guid application)
        {
            var result = new List<KeyValuePair<string, string>>();

            await Task.Run(() =>
            {
                if (db.ContainsKey(application))
                    result.AddRange(db[application]);
            });

            return result;
        }

        public async Task<string> GetSettings(Guid application, string key)
        {
            var result = string.Empty;

            await Task.Run(() =>
            {
                if (db.ContainsKey(application))
                    result = db[application].FirstOrDefault(i => i.Key.Equals(key)).Value;
            });

            return result;
        }

        public async Task<Guid> Create(Guid application, string key, string value)
        {
            var result = Guid.Empty;

            await Task.Run(() =>
            {
                if (db.ContainsKey(application))
                    db[application].Add(new KeyValuePair<string, string>(key, value));
            });

            return result;
        }

        public async Task<bool> Update(Guid application, string key, string value)
        {
            var result = false;

            await Task.Run(() =>
            {
                if (db.ContainsKey(application))
                {
                    var config = db[application].FirstOrDefault(i => i.Key.Equals(key));

                    db[application].Remove(config);

                    db[application].Add(new KeyValuePair<string, string>(key, value));
                }
            });

            return result;
        }

        public async Task<bool> Delete(Guid application, string key)
        {
            var result = false;

            await Task.Run(() =>
            {
                if (db.ContainsKey(application))
                {
                    var config = db[application].FirstOrDefault(i => i.Key.Equals(key));

                    db[application].Remove(config);
                }
            });

            return result;
        }
    }
}