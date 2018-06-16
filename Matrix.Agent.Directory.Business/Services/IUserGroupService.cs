using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Matrix.Agent.Directory.Model;
using Matrix.Framework.Business;

namespace Matrix.Agent.Directory.Business.Services
{
    public interface IUserGroupService : IService
    {
        Task<List<UserGroup>> GetUserGroups(Guid application);

        Task<UserGroup> GetUserGroupById(Guid id);

        Task<UserGroup> GetUserGroupByName(Guid application, string name);

        Task<Guid> CreateUserGroup(Guid application, string name, string description);

        Task<bool> UpdateUserGroup(Guid id, string name, string description);

        Task<bool> DeleteUserGroup(Guid id);
    }
}