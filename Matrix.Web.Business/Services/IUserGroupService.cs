using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Matrix.Agent.Directory.Model;
using Matrix.Framework.Business;

namespace Matrix.Web.Business.Services
{
    public interface IUserGroupService : IService
    {
        Task<List<UserGroup>> GetUserGroups(Guid application);

        Task<Guid> CreateUserGroup(Guid application, string name, string description);

        Task<bool> UpdateUserGroup(Guid application, Guid id, string name, string description);

        Task<bool> DeleteUserGroup(Guid application, Guid id);
    }
}