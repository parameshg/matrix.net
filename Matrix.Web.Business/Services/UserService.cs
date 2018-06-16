using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Matrix.Agent.Directory.Model;
using Matrix.Framework.Business;

namespace Matrix.Web.Business.Services
{
    public class UserService : Service, IUserService
    {
        public UserService(IServiceContext context)
            : base(context)
        {
        }

        public Task<User> GetUserById(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<User> GetUserByUsername(Guid application, string username)
        {
            throw new NotImplementedException();
        }

        public Task<List<User>> GetUsers(Guid application)
        {
            throw new NotImplementedException();
        }

        public Task<Guid> CreateUser(Guid application, string firstName, string lastName, string username, string password, string email, string phone)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateUserPassword(Guid id, string password)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateUserProfile(Guid id, string firstName, string lastName, string email, string phone)
        {
            throw new NotImplementedException();
        }

        public Task<bool> AddUserGroups(Guid userId, params Guid[] groups)
        {
            throw new NotImplementedException();
        }

        public Task<bool> AddUserRoles(Guid userId, params Guid[] roles)
        {
            throw new NotImplementedException();
        }

        public Task<bool> RemoveUserGroups(Guid userId, params Guid[] groups)
        {
            throw new NotImplementedException();
        }

        public Task<bool> RemoveUserRoles(Guid userId, params Guid[] roles)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteUser(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}