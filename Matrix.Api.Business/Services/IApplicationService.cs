using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Matrix.Agent.Registry.Model;

namespace Matrix.Api.Business.Services
{
    public interface IApplicationService
    {
        Task<List<Application>> GetApplications();

        Task<bool> Login(Guid application);

        Task<bool> Logout(Guid application);
    }
}