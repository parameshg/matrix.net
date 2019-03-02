using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Matrix.Agent.Directory.Model;
using Matrix.Framework.Business;
using Matrix.Web.Business.Services;
using RestSharp;

namespace Matrix.Web.Business.Proxy
{
    public class UserRoleService : Service, IUserRoleService
    {
        private RestClient Api { get; set; }

        public UserRoleService(IServiceContext context)
            : base(context)
        {
            Api = new RestClient(context.Directory);
        }

        public async Task<List<UserRole>> GetUserRoles(Guid application)
        {
            var result = new List<UserRole>();

            var request = new RestRequest("/applications/{application}/userroles", Method.GET);

            request.AddUrlSegment("application", application);

            var response = await Api.ExecuteTaskAsync<List<UserRole>>(request);

            if (response.StatusCode.Equals(HttpStatusCode.OK))
            {
                result.AddRange(response.Data);
            }

            return result;
        }

        public async Task<Guid> CreateUserRole(Guid application, string name, string description)
        {
            var result = Guid.Empty;

            var request = new RestRequest("/applications/{application}/userroles", Method.POST);

            request.AddUrlSegment("application", application);

            request.AddJsonBody(new
            {
                application,
                name,
                description
            });

            var response = await Api.ExecuteTaskAsync<Guid>(request);

            if (response.StatusCode.Equals(HttpStatusCode.OK))
            {
                result = response.Data;
            }

            return result;
        }

        public async Task<bool> UpdateUserRole(Guid application, Guid id, string name, string description)
        {
            var result = false;

            var request = new RestRequest("/applications/{application}/userroles", Method.PUT);

            request.AddUrlSegment("application", application);

            request.AddJsonBody(new
            {
                application,
                id,
                name,
                description
            });

            var response = await Api.ExecuteTaskAsync<bool>(request);

            if (response.StatusCode.Equals(HttpStatusCode.OK))
            {
                result = response.Data;
            }

            return result;
        }

        public async Task<bool> DeleteUserRole(Guid application, Guid id)
        {
            var result = false;

            var request = new RestRequest("/applications/{application}/userroles/{id}", Method.DELETE);

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