using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Matrix.Agent.Directory.Model;

namespace Matrix.Agent.Directory.Database.Repositories
{
    public interface IUserRepository
    {
        Task<List<User>> GetUsers(Guid application);

        Task<User> GetUserById(Guid id);

        Task<User> GetUserByUsername(Guid application, string username);

        Task<Guid> CreateUser(Guid application, string firstName, string lastName, string username, string password, string email, string phone);

        Task<bool> UpdateUserProfile(Guid id, string firstName, string lastName, string email, string phone);

        Task<bool> UpdateUserPassword(Guid id, string password);

        Task<bool> AddUserRoles(Guid userId, params Guid[] roles);

        Task<bool> RemoveUserRoles(Guid userId, params Guid[] roles);

        Task<bool> AddUserGroups(Guid userId, params Guid[] groups);

        Task<bool> RemoveUserGroups(Guid userId, params Guid[] groups);

        Task<bool> DeleteUser(Guid id);
    }
}