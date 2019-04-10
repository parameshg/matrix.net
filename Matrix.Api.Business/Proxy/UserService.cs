using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EnsureThat;
using Matrix.Agent.Directory.Model;
using Matrix.Api.Business.Services;
using Matrix.Framework.Business;
using RestSharp;

namespace Matrix.Api.Business.Proxy
{
    public class UserService : Service, IUserService
    {
        public UserService(IServiceContext context)
            : base(context)
        {
        }

        public async Task<List<User>> GetUsers(Guid application)
        {
            var result = new List<User>();

            Ensure.Guid.IsNotEmpty(application);

            var request = new RestRequest("/applications/{application}/users", Method.GET);

            request.AddUrlSegment("application", application);

            var response = await Execute<IEnumerable<User>>(new RestClient(Context.Directory), request);

            Ensure.Any.IsNotNull(response);

            result.AddRange(response);

            return result;
        }

        public async Task<User> GetUserById(Guid application, Guid id)
        {
            User result = null;

            var request = new RestRequest("/applications/{application}/users/{id}", Method.GET);

            request.AddUrlSegment("application", application);

            request.AddUrlSegment("id", id);

            var response = await Execute<User>(new RestClient(Context.Directory), request);

            Ensure.Any.IsNotNull(response);

            result = response;

            return result;
        }

        public Task<User> GetUserByUsername(Guid application, string username)
        {
            throw new NotImplementedException();
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

            result = await Execute<bool>(new RestClient(Context.Directory), request);

            return result;
        }
    }
}