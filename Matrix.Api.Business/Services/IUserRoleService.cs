using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Matrix.Agent.Directory.Model;
using Matrix.Framework.Business;

namespace Matrix.Api.Business.Services
{
    public interface IUserRoleService : IService
    {
        Task<List<UserRole>> GetUserRoles(Guid application);
    }
}