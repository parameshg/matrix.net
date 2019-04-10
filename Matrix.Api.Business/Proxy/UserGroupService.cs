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
    public class UserGroupService : Service, IUserGroupService
    {
        public UserGroupService(IServiceContext context)
            : base(context)
        {
        }

        public async Task<List<UserGroup>> GetUserGroups(Guid application)
        {
            var result = new List<UserGroup>();

            var request = new RestRequest("/applications/{application}/usergroups", Method.GET);

            request.AddUrlSegment("application", application);

            var response = await Execute<IEnumerable<UserGroup>>(new RestClient(Context.Directory), request);

            Ensure.Any.IsNotNull(response);

            result.AddRange(response);

            return result;
        }
    }
}