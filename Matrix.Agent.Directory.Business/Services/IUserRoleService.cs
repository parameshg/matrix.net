using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Matrix.Agent.Directory.Model;
using Matrix.Framework.Business;

namespace Matrix.Agent.Directory.Business.Services
{
    public interface IUserRoleService : IService
    {
        Task<List<UserRole>> GetUserRoles(Guid application);

        Task<UserRole> GetUserRoleById(Guid id);

        Task<UserRole> GetUserRoleByName(Guid application, string name);

        Task<Guid> CreateUserRole(Guid application, string name, string description);

        Task<bool> UpdateUserRole(Guid id, string name, string description);

        Task<bool> DeleteUserRole(Guid id);
    }
}