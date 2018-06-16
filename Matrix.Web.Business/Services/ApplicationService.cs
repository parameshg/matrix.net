using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Matrix.Agent.Registry.Model;
using Matrix.Framework.Business;

namespace Matrix.Web.Business.Services
{
    public class ApplicationService : Service, IApplicationService
    {
        public ApplicationService(IServiceContext context)
            : base(context)
        {
        }

        public Task<List<Application>> Get()
        {
            throw new NotImplementedException();
        }

        public Task<Guid> Register(string name, string description)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Update(Guid id, string name, string description)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Delete(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}