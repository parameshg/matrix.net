using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Matrix.Agent.Directory.Model;

namespace Matrix.Agent.Directory.Database.Repositories
{
    public interface IUserRoleRepository
    {
        Task<List<UserRole>> GetUserRoles(Guid application);

        Task<UserRole> GetUserRoleById(Guid id);

        Task<UserRole> GetUserRoleByName(Guid application, string name);

        Task<Guid> CreateUserRole(Guid application, string name, string description);

        Task<bool> UpdateUserRole(Guid id, string name, string description);

        Task<bool> DeleteUserRole(Guid id);
    }
}