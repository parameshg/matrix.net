using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Matrix.Agent.Registry.Model;

namespace Matrix.Web.Business.Services
{
    public interface IApplicationService
    {
        Task<List<Application>> GetApplications();

        Task<Guid> Register(string name, string description);

        Task<bool> Update(Guid id, string name, string description);

        Task<bool> Delete(Guid id);
    }
}