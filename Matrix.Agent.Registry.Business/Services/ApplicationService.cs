using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Matrix.Agent.Registry.Database;
using Matrix.Agent.Registry.Database.Repositories;
using Matrix.Agent.Registry.Model;
using Matrix.Framework.Business;

namespace Matrix.Agent.Registry.Business.Services
{
    public class ApplicationService : Service, IApplicationService
    {
        public IApplicationRepository Repository { get; }

        public ApplicationService(IServiceContext context, IApplicationRepository repository)
            : base(context)
        {
            Repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        public async Task<List<Application>> Get()
        {
            var result = new List<Application>();

            result.AddRange(await Repository.Get());

            return result;
        }

        public async Task<Guid> Register(string name, string description)
        {
            var result = Guid.Empty;

            result = await Repository.Create(name, description);

            return result;
        }

        public async Task<bool> Update(Guid id, string name, string description)
        {
            var result = false;

            result = await Repository.Update(id, name, description);

            return result;
        }

        public async Task<bool> Delete(Guid id)
        {
            var result = false;

            result = await Repository.Delete(id);

            return result;
        }
    }
}