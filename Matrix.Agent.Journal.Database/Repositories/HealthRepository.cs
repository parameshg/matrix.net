using System;
using System.Threading.Tasks;
using Matrix.Framework;
using Matrix.Framework.Database;

namespace Matrix.Agent.Journal.Database.Repositories
{
    public class HealthRepository : Repository, IHealthRepository
    {
        private JournalDbContext db { get; }

        public HealthRepository(IRepositoryContext context, JournalDbContext dbContext)
            : base(context)
        {
            db = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        public async Task<Health> Test()
        {
            var result = new Health();

            try
            {
                await db.Logs.AddAsync(new Entities.LogEntry()
                {
                    Timestamp = DateTime.Now,
                    Application = Guid.Empty,
                    Source = "HEALTH",
                    Level = 0,
                    Event = 0,
                    Message = "Test"
                });

                await db.SaveChangesAsync();
            }
            catch (Exception e)
            {
                result.Errors.Add(e.Message);
            }

            return result;
        }
    }
}