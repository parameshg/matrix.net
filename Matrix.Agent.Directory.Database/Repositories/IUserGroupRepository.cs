using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Matrix.Agent.Directory.Model;

namespace Matrix.Agent.Directory.Database.Repositories
{
    public interface IUserGroupRepository
    {
        Task<List<UserGroup>> GetUserGroups(Guid application);

        Task<UserGroup> GetUserGroupById(Guid id);

        Task<UserGroup> GetUserGroupByName(Guid application, string name);

        Task<Guid> CreateUserGroup(Guid application, string name, string description);

        Task<bool> UpdateUserGroup(Guid id, string name, string description);

        Task<bool> DeleteUserGroup(Guid id);
    }
}