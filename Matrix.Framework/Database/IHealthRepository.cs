using System.Threading.Tasks;

namespace Matrix.Framework.Database
{
    public interface IHealthRepository : IRepository
    {
        Task<Health> Test();
    }
}