using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Matrix.Agent.Directory.Model;
using Matrix.Framework.Business;

namespace Matrix.Web.Business.Services
{
    public class UserRoleService : Service, IUserRoleService
    {
        public UserRoleService(IServiceContext context)
            : base(context)
        {
        }

        public Task<UserRole> GetUserRoleById(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<UserRole> GetUserRoleByName(Guid application, string name)
        {
            throw new NotImplementedException();
        }

        public Task<List<UserRole>> GetUserRoles(Guid application)
        {
            throw new NotImplementedException();
        }

        public Task<Guid> CreateUserRole(Guid application, string name, string description)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateUserRole(Guid id, string name, string description)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteUserRole(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}