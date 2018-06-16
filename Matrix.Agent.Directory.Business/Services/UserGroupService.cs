using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Matrix.Agent.Directory.Database.Repositories;
using Matrix.Agent.Directory.Model;
using Matrix.Framework.Business;

namespace Matrix.Agent.Directory.Business.Services
{
    public class UserGroupService : Service, IUserGroupService
    {
        public IUserGroupRepository Repository { get; }

        public UserGroupService(IServiceContext context, IUserGroupRepository repository)
            : base(context)
        {
            Repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        public async Task<List<UserGroup>> GetUserGroups(Guid application)
        {
            var result = new List<UserGroup>();

            result.AddRange(await Repository.GetUserGroups(application));

            return result;
        }

        public async Task<UserGroup> GetUserGroupById(Guid id)
        {
            UserGroup result = null;

            result = await Repository.GetUserGroupById(id);

            return result;
        }

        public async Task<UserGroup> GetUserGroupByName(Guid application, string name)
        {
            UserGroup result = null;

            result = await Repository.GetUserGroupByName(application, name);

            return result;
        }

        public async Task<Guid> CreateUserGroup(Guid application, string name, string description)
        {
            var result = Guid.Empty;

            result = await Repository.CreateUserGroup(application, name, description);

            return result;
        }

        public async Task<bool> UpdateUserGroup(Guid id, string name, string description)
        {
            var result = false;

            result = await Repository.UpdateUserGroup(id, name, description);

            return result;
        }

        public async Task<bool> DeleteUserGroup(Guid id)
        {
            var result = false;

            result = await Repository.DeleteUserGroup(id);

            return result;
        }
    }
}