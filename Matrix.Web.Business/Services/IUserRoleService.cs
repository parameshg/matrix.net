using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Matrix.Agent.Directory.Model;
using Matrix.Framework.Business;

namespace Matrix.Web.Business.Services
{
    public interface IUserRoleService : IService
    {
        Task<List<UserRole>> GetUserRoles(Guid application);

        Task<Guid> CreateUserRole(Guid application, string name, string description);

        Task<bool> UpdateUserRole(Guid application, Guid id, string name, string description);

        Task<bool> DeleteUserRole(Guid application, Guid id);
    }
}