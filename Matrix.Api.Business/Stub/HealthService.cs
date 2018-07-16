using System.Threading.Tasks;
using Matrix.Framework;
using Matrix.Framework.Business;

namespace Matrix.Api.Business.Stub
{
    public class HealthService : Service, Services.IHealthService
    {
        public HealthService(IServiceContext context)
            : base(context)
        {
        }

        public async Task<Health> GetConfiguratorHealth()
        {
            Health result = null;

            await Task.Run(() =>
            {
                result = new Health();
            });

            return result;
        }

        public async Task<Health> GetDirectoryHealth()
        {
            Health result = null;

            await Task.Run(() =>
            {
                result = new Health();
            });

            return result;
        }

        public async Task<Health> GetJournalHealth()
        {
            Health result = null;

            await Task.Run(() =>
            {
                result = new Health();
            });

            return result;
        }

        public async Task<Health> GetPostmanHealth()
        {
            Health result = null;

            await Task.Run(() =>
            {
                result = new Health();
            });

            return result;
        }

        public async Task<Health> GetRegistryHealth()
        {
            Health result = null;

            await Task.Run(() =>
            {
                result = new Health();
            });

            return result;
        }
    }
}