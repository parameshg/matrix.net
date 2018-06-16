using System;
using System.Threading.Tasks;
using Matrix.Framework;
using Matrix.Framework.Business;
using Matrix.Framework.Database;

namespace Matrix.Agent.Directory.Business.Services
{
    public class HealthService : Service, IHealthService
    {
        public IHealthRepository Repository { get; }

        public HealthService(IServiceContext context, IHealthRepository repository)
            : base(context)
        {
            Repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        public async Task<Health> Test()
        {
            var result = new Health();

            var test = await Repository.Test();

            if (test != null)
                result.Errors.AddRange(test.Errors);

            return result;
        }
    }
}