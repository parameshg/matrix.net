using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Matrix.Framework.Database;

namespace Matrix.Agent.Configurator.Database.Repositories
{
    public class ConfigurationRepository : Repository, IConfigurationRepository
    {
        private ConfiguratorDbContext db { get; }

        public ConfigurationRepository(IRepositoryContext context, ConfiguratorDbContext dbContext)
            : base(context)
        {
            db = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        public async Task<List<KeyValuePair<string, string>>> GetSettings(Guid application)
        {
            var result = new List<KeyValuePair<string, string>>();

            await Task.Run(() =>
            {
                var entity = db.Settings.Where(i => i.Application.Equals(application)).ToList();

                if (entity != null)
                {
                    foreach (var i in entity)
                        result.Add(new KeyValuePair<string, string>(i.Key, i.Value));
                }
            });

            return result;
        }

        public async Task<string> GetSettings(Guid application, string key)
        {
            var result = string.Empty;

            await Task.Run(() =>
            {
                var entity = db.Settings.FirstOrDefault(i => i.Application.Equals(application) && i.Key.Equals(key));

                if (entity != null)
                    result = entity.Value;
            });

            return result;
        }

        public async Task<Guid> Create(Guid application, string key, string value)
        {
            var result = Guid.Empty;

            var id = Guid.NewGuid();

            var entity = db.Settings.Add(new Entities.Settings()
            {
                Id = id,
                Application = application,
                Key = key,
                Value = value
            });

            if (await db.SaveChangesAsync() > 0)
                result = id;

            return result;
        }

        public async Task<bool> Update(Guid application, string key, string value)
        {
            var result = false;

            var entity = db.Settings.FirstOrDefault(i => i.Application.Equals(application) && i.Key.Equals(key));

            if (entity != null)
            {
                entity.Key = key;
                entity.Value = value;

                db.Settings.Update(entity);
                result = await db.SaveChangesAsync() > 0;
            }

            return result;
        }

        public async Task<bool> Delete(Guid application, string key)
        {
            var result = false;

            var entity = db.Settings.FirstOrDefault(i => i.Application.Equals(application) && i.Key.Equals(key));

            if (entity != null)
            {
                db.Settings.Remove(entity);

                result = await db.SaveChangesAsync() > 0;
            }

            return result;
        }
    }
}