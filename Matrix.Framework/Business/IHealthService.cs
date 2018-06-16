using System.Threading.Tasks;

namespace Matrix.Framework.Business
{
    public interface IHealthService : IService
    {
        Task<Health> Test();
    }
}