using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Matrix.Agent.Registry.Model;
using Matrix.Framework.Database;
using PowerMapper;

namespace Matrix.Agent.Registry.Database.Repositories
{
    public class ApplicationRepository : Repository, IApplicationRepository
    {
        private readonly RegistryDbContext db;

        public ApplicationRepository(IRepositoryContext context, RegistryDbContext database)
            : base(context)
        {
            db = database ?? throw new ArgumentNullException(nameof(database));
        }

        public async Task<List<Application>> Get()
        {
            var result = new List<Application>();

            await Task.Run(() =>
            {
                result.AddRange(Mapper.Map<Entities.Application, Application>(db.Applications.ToArray()));
            });

            return result;
        }

        public async Task<Guid> Create(string name, string description)
        {
            var result = Guid.Empty;

            var id = Guid.NewGuid();

            var entity = db.Applications.Add(new Entities.Application()
            {
                Id = id,
                Name = name,
                Description = description
            });

            if (await db.SaveChangesAsync() > 0)
                result = id;

            return result;
        }

        public async Task<bool> Update(Guid id, string name, string description)
        {
            var result = false;

            var entity = db.Applications.FirstOrDefault(i => i.Id.Equals(id));

            if (entity != null)
            {
                entity.Name = name;
                entity.Description = description;

                db.Applications.Update(entity);
                result = await db.SaveChangesAsync() > 0;
            }

            return result;
        }

        public async Task<bool> Delete(Guid id)
        {
            var result = false;

            var entity = db.Applications.FirstOrDefault(i => i.Id.Equals(id));

            if (entity != null)
            {
                db.Applications.Remove(entity);
                result = await db.SaveChangesAsync() > 0;
            }

            return result;
        }
    }
}