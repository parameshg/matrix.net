using System.Threading.Tasks;
using Matrix.Framework;

namespace Matrix.Web.Business.Services
{
    public interface IHealthService
    {
        Task<Health> GetRegistryHealth();

        Task<Health> GetConfiguratorHealth();

        Task<Health> GetJournalHealth();

        Task<Health> GetDirectoryHealth();

        Task<Health> GetPostmanHealth();
    }
}