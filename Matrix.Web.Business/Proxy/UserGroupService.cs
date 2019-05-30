using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Matrix.Agent.Directory.Model;
using Matrix.Framework.Api.Response;
using Matrix.Framework.Business;
using Matrix.Web.Business.Services;
using RestSharp;

namespace Matrix.Web.Business.Proxy
{
    public class UserGroupService : Service, IUserGroupService
    {
        private RestClient Api { get; set; }

        public UserGroupService(IServiceContext context) : base(context)
        {
            Api = new RestClient(context.Directory);
        }

        public async Task<List<UserGroup>> GetUserGroups(Guid application)
        {
            var result = new List<UserGroup>();

            var request = new RestRequest("/applications/{application}/usergroups", Method.GET);

            request.AddUrlSegment("application", application);

            var response = await Api.ExecuteTaskAsync<SuccessResponse<List<UserGroup>>>(request);

            if (response.StatusCode.Equals(HttpStatusCode.OK))
            {
                result.AddRange(response.Data.Data);
            }

            return result;
        }

        public async Task<Guid> CreateUserGroup(Guid application, string name, string description)
        {
            var result = Guid.Empty;

            var request = new RestRequest("/applications/{application}/usergroups", Method.POST);

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

        public async Task<bool> UpdateUserGroup(Guid application, Guid id, string name, string description)
        {
            var result = false;

            var request = new RestRequest("/applications/{application}/usergroups", Method.PUT);

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

        public async Task<bool> DeleteUserGroup(Guid application, Guid id)
        {
            var result = false;

            var request = new RestRequest("/applications/{application}/usergroups/{id}", Method.DELETE);

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