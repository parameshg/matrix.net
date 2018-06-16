using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Matrix.Agent.Directory.Model;
using Matrix.Framework.Business;

namespace Matrix.Web.Business.Services
{
    public class UserGroupService : Service, IUserGroupService
    {
        public UserGroupService(IServiceContext context) : base(context)
        {
        }

        public Task<UserGroup> GetUserGroupById(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<UserGroup> GetUserGroupByName(Guid application, string name)
        {
            throw new NotImplementedException();
        }

        public Task<List<UserGroup>> GetUserGroups(Guid application)
        {
            throw new NotImplementedException();
        }

        public Task<Guid> CreateUserGroup(Guid application, string name, string description)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateUserGroup(Guid id, string name, string description)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteUserGroup(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}