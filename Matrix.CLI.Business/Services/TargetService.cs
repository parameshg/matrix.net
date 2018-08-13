using System.Collections.Generic;
using System.Threading.Tasks;
using Matrix.CLI.Database.Repositories;
using Matrix.CLI.Model;

namespace Matrix.CLI.Business.Services
{
    public class TargetService : ITargetService
    {
        public ITargetRepository Repository { get; }

        public TargetService(ITargetRepository repository)
        {
            Repository = repository ?? throw new System.ArgumentNullException(nameof(repository));
        }

        public async Task<IList<TargetEntry>> GetTargets()
        {
            var result = new List<TargetEntry>();

            result.AddRange(await Repository.GetTargets());

            return result;
        }

        public async Task<TargetEntry> GetTarget(string name)
        {
            TargetEntry result = null;

            result = await Repository.GetTarget(name);

            return result;
        }

        public async Task<bool> SaveTarget(string name, string url)
        {
            var result = false;

            result = await Repository.SaveTarget(name, url);

            return result;
        }

        public async Task<bool> RemoveTarget(string name)
        {
            var result = false;

            result = await Repository.RemoveTarget(name);

            return result;
        }

        public async Task<bool> ClearTargets()
        {
            var result = false;

            result = await Repository.ClearTargets();

            return result;
        }
    }
}