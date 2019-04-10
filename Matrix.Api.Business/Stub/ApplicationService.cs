using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EnsureThat;
using Matrix.Agent.Registry.Model;
using Matrix.Api.Business.Services;
using Matrix.Framework.Business;
using Matrix.Framework.Constants;

namespace Matrix.Api.Business.Stub
{
    public class ApplicationService : Service, IApplicationService
    {
        private List<Application> db { get; set; }

        public ApplicationService(IServiceContext context)
            : base(context)
        {
            db = new List<Application>();

            db.Add(new Application()
            {
                Id = This.Id,
                Name = This.Name,
                Description = This.Description
            });

            db.Add(new Application()
            {
                Id = Default.Id,
                Name = Default.Name,
                Description = Default.Description
            });
        }

        public async Task<List<Application>> GetApplications()
        {
            var result = new List<Application>();

            await Task.Run(() => { result.AddRange(db); });

            return result;
        }

        public async Task<bool> Login(Guid application)
        {
            var result = false;

            Ensure.Guid.IsNotEmpty(application);

            var applications = await GetApplications();

            result = applications.Count(i => i.Id.Equals(application)).Equals(1);

            return result;
        }

        public async Task<bool> Logout(Guid application)
        {
            var result = false;

            Ensure.Guid.IsNotEmpty(application);

            var applications = await GetApplications();

            result = applications.Count(i => i.Id.Equals(application)).Equals(1);

            return result;
        }
    }
}