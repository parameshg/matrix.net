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
    public class UserRoleService : Service, IUserRoleService
    {
        public UserRoleService(IServiceContext context)
            : base(context)
        {
        }

        public async Task<List<UserRole>> GetUserRoles(Guid application)
        {
            var result = new List<UserRole>();

            var request = new RestRequest("/applications/{application}/userroles", Method.GET);

            request.AddUrlSegment("application", application);

            var response = await Execute<IEnumerable<UserRole>>(new RestClient(Context.Directory), request);

            Ensure.Any.IsNotNull(response);

            result.AddRange(response);

            return result;
        }
    }
}