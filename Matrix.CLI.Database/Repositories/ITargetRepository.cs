using System.Collections.Generic;
using System.Threading.Tasks;
using Matrix.CLI.Model;
using Matrix.Framework.Database;

namespace Matrix.CLI.Database.Repositories
{
    public interface ITargetRepository : IRepository
    {
        Task<IList<TargetEntry>> GetTargets();

        Task<TargetEntry> GetTarget(string name);

        Task<bool> SaveTarget(string name, string url);

        Task<bool> RemoveTarget(string name);

        Task<bool> ClearTargets();
    }
}