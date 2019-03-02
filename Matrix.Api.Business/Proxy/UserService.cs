using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Matrix.Agent.Directory.Model;
using Matrix.Api.Business.Services;
using Matrix.Framework.Business;
using RestSharp;

namespace Matrix.Api.Business.Proxy
{
    public class UserService : Service, IUserService
    {
        private RestClient Api { get; set; }

        public UserService(IServiceContext context)
            : base(context)
        {
            Api = new RestClient(context.Directory);
        }

        public async Task<List<User>> GetUsers(Guid application)
        {
            var result = new List<User>();

            var request = new RestRequest("/applications/{application}/users", Method.GET);

            request.AddUrlSegment("application", application);

            var response = await Api.ExecuteTaskAsync<List<User>>(request);

            if (response.StatusCode.Equals(HttpStatusCode.OK))
            {
                result.AddRange(response.Data);
            }

            return result;
        }

        public async Task<User> GetUserById(Guid application, Guid id)
        {
            User result = null;

            var request = new RestRequest("/applications/{application}/users/{id}", Method.GET);

            request.AddUrlSegment("application", application);
            request.AddUrlSegment("id", id);

            var response = await Api.ExecuteTaskAsync<User>(request);

            if (response.StatusCode.Equals(HttpStatusCode.OK))
            {
                result = response.Data;
            }

            return result;
        }

        public Task<User> GetUserByUsername(Guid application, string username)
        {
            throw new NotImplementedException();
        }

        public async Task<Guid> CreateUser(Guid application, string firstName, string lastName, string username, string password, string email, string phone)
        {
            var result = Guid.Empty;

            var request = new RestRequest("/applications/{application}/users", Method.POST);

            request.AddUrlSegment("application", application);

            request.AddJsonBody(new
            {
                application,
                firstName,
                lastName,
                username,
                password,
                email,
                phone
            });

            var response = await Api.ExecuteTaskAsync<Guid>(request);

            if (response.StatusCode.Equals(HttpStatusCode.OK))
            {
                result = response.Data;
            }

            return result;
        }

        public Task<bool> UpdateUserPassword(Guid id, string password)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> UpdateUserProfile(Guid application, Guid id, string firstName, string lastName, string email, string phone)
        {
            var result = false;

            var request = new RestRequest("/applications/{application}/users", Method.PUT);

            request.AddUrlSegment("application", application);

            request.AddJsonBody(new
            {
                application,
                firstName,
                lastName,
                email,
                phone
            });

            var response = await Api.ExecuteTaskAsync<bool>(request);

            if (response.StatusCode.Equals(HttpStatusCode.OK))
            {
                result = response.Data;
            }

            return result;
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

        public async Task<bool> DeleteUser(Guid application, Guid id)
        {
            var result = false;

            var request = new RestRequest("/applications/{application}/users/{id}", Method.DELETE);

            request.AddUrlSegment("application", application);
            request.AddUrlSegment("id", id);

            var response = await Api.ExecuteTaskAsync<bool>(request);

            if (response.StatusCode.Equals(HttpStatusCode.OK))
            {
                result = response.Data;
            }

            return result;
        }
    }
}