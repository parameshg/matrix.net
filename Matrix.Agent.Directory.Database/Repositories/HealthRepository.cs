using System;
using System.Linq;
using System.Threading.Tasks;
using Matrix.Framework;
using Matrix.Framework.Database;

namespace Matrix.Agent.Directory.Database.Repositories
{
    public class HealthRepository : Repository, IHealthRepository
    {
        private DirectoryDbContext db { get; }

        public HealthRepository(IRepositoryContext context, DirectoryDbContext dbContext)
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
                    var user = db.Users.SingleOrDefault(i => i.Id.Equals(Guid.Empty));
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