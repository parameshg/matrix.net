using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Matrix.Agent.Directory.Model;
using Matrix.Api.Business.Services;
using Matrix.Framework.Business;

namespace Matrix.Api.Business.Stub
{
    public class UserRoleService : Service, IUserRoleService
    {
        private Dictionary<Guid, List<UserRole>> db { get; set; }

        public UserRoleService(IServiceContext context) : base(context)
        {
            db = new Dictionary<Guid, List<UserRole>>();
        }

        public async Task<List<UserRole>> GetUserRoles(Guid application)
        {
            var result = new List<UserRole>();

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