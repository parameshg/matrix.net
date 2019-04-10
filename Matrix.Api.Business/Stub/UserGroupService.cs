using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Matrix.Agent.Directory.Model;
using Matrix.Api.Business.Services;
using Matrix.Framework.Business;

namespace Matrix.Api.Business.Stub
{
    public class UserGroupService : Service, IUserGroupService
    {
        private Dictionary<Guid, List<UserGroup>> db { get; set; }

        public UserGroupService(IServiceContext context) : base(context)
        {
            db = new Dictionary<Guid, List<UserGroup>>();
        }

        public async Task<List<UserGroup>> GetUserGroups(Guid application)
        {
            var result = new List<UserGroup>();

            await Task.Run(() =>
            {
                if (db.ContainsKey(application))
                {
                    result.AddRange(db[application]);
                }
            });

            return result;
        }
    }
}