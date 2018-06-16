using System;
using System.Linq;
using System.Threading.Tasks;
using Matrix.Framework;
using Matrix.Framework.Database;

namespace Matrix.Agent.Registry.Database.Repositories
{
    public class HealthRepository : Repository, IHealthRepository
    {
        private RegistryDbContext db { get; }

        public HealthRepository(IRepositoryContext context, RegistryDbContext dbContext)
            : base(context)
        {
            db = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        public async Task<Health> Test()
        {
            var result = new Health();

            try
            {
                await Task.Run(() =>
                {
                    var app = db.Applications.SingleOrDefault(i => i.Id.Equals(Guid.Empty));
                });
            }
            catch (Exception e)
            {
                result.Errors.Add(e.Message);
            }

            return result;
        }
    }
}