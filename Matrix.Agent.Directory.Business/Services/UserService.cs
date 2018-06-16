using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Matrix.Agent.Directory.Database.Repositories;
using Matrix.Agent.Directory.Model;
using Matrix.Framework.Business;

namespace Matrix.Agent.Directory.Business.Services
{
    public class UserService : Service, IUserService
    {
        public IUserRepository Repository { get; }

        public UserService(IServiceContext context, IUserRepository repository)
            : base(context)
        {
            Repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        public async Task<List<User>> GetUsers(Guid application)
        {
            var result = new List<User>();

            result.AddRange(await Repository.GetUsers(application));

            return result;
        }

        public async Task<User> GetUserById(Guid id)
        {
            User result = null;

            result = await Repository.GetUserById(id);

            return result;
        }

        public async Task<User> GetUserByUsername(Guid application, string username)
        {
            User result = null;

            result = await Repository.GetUserByUsername(application, username);

            return result;
        }

        public async Task<Guid> CreateUser(Guid application, string firstName, string lastName, string username, string password, string email, string phone)
        {
            var result = Guid.Empty;

            result = await Repository.CreateUser(application, firstName, lastName, username, password, email, phone);

            return result;
        }

        public async Task<bool> UpdateUserProfile(Guid id, string firstName, string lastName, string email, string phone)
        {
            var result = false;

            result = await Repository.UpdateUserProfile(id, firstName, lastName, email, phone);

            return result;
        }

        public async Task<bool> UpdateUserPassword(Guid id, string password)
        {
            var result = false;

            result = await Repository.UpdateUserPassword(id, password);

            return result;
        }

        public async Task<bool> AddUserGroups(Guid userId, params Guid[] groups)
        {
            var result = false;

            result = await Repository.AddUserGroups(userId, groups);

            return result;
        }

        public async Task<bool> AddUserRoles(Guid userId, params Guid[] roles)
        {
            var result = false;

            result = await Repository.AddUserRoles(userId, roles);

            return result;
        }

        public async Task<bool> RemoveUserGroups(Guid userId, params Guid[] groups)
        {
            var result = false;

            result = await Repository.RemoveUserGroups(userId, groups);

            return result;
        }

        public async Task<bool> RemoveUserRoles(Guid userId, params Guid[] roles)
        {
            var result = false;

            result = await Repository.RemoveUserRoles(userId, roles);

            return result;
        }

        public async Task<bool> DeleteUser(Guid id)
        {
            var result = false;

            result = await Repository.DeleteUser(id);

            return result;
        }
    }
}