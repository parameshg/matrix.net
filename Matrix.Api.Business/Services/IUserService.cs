using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Matrix.Agent.Directory.Model;
using Matrix.Framework.Business;

namespace Matrix.Api.Business.Services
{
    public interface IUserService : IService
    {
        Task<List<User>> GetUsers(Guid application);

        Task<User> GetUserById(Guid application, Guid id);

        Task<User> GetUserByUsername(Guid application, string username);

        Task<bool> UpdateUserProfile(Guid application, Guid id, string firstName, string lastName, string email, string phone);

        Task<bool> UpdateUserPassword(Guid id, string password);
    }
}