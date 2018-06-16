using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Matrix.Agent.Directory.Database.Repositories;
using Matrix.Agent.Directory.Model;
using Matrix.Framework.Business;

namespace Matrix.Agent.Directory.Business.Services
{
    public class UserRoleService : Service, IUserRoleService
    {
        public IUserRoleRepository Repository { get; }

        public UserRoleService(IServiceContext context, IUserRoleRepository repository)
            : base(context)
        {
            Repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        public async Task<List<UserRole>> GetUserRoles(Guid application)
        {
            var result = new List<UserRole>();

            result.AddRange(await Repository.GetUserRoles(application));

            return result;
        }

        public async Task<UserRole> GetUserRoleById(Guid id)
        {
            UserRole result = null;

            result = await Repository.GetUserRoleById(id);

            return result;
        }

        public async Task<UserRole> GetUserRoleByName(Guid application, string name)
        {
            UserRole result = null;

            result = await Repository.GetUserRoleByName(application, name);

            return result;
        }

        public async Task<Guid> CreateUserRole(Guid application, string name, string description)
        {
            var result = Guid.Empty;

            result = await Repository.CreateUserRole(application, name, description);

            return result;
        }

        public async Task<bool> UpdateUserRole(Guid id, string name, string description)
        {
            var result = false;

            result = await Repository.UpdateUserRole(id, name, description);

            return result;
        }

        public async Task<bool> DeleteUserRole(Guid id)
        {
            var result = false;

            result = await Repository.DeleteUserRole(id);

            return result;
        }
    }
}