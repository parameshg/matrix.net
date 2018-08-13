using System.Collections.Generic;
using System.Threading.Tasks;
using Matrix.CLI.Model;
using Matrix.Framework.Business;

namespace Matrix.CLI.Business.Services
{
    public interface ITargetService : IService
    {
        Task<IList<TargetEntry>> GetTargets();

        Task<TargetEntry> GetTarget(string name);

        Task<bool> SaveTarget(string name, string url);

        Task<bool> RemoveTarget(string name);

        Task<bool> ClearTargets();
    }
}