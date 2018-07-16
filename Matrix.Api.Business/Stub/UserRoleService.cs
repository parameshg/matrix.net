using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Matrix.Agent.Directory.Model;
using Matrix.Api.Business.Services;
using Matrix.Framework.Business;
using Matrix.Framework.Constants;
using Matrix.Threading;

namespace Matrix.Api.Business.Stub
{
    public class UserRoleService : Service, IUserRoleService
    {
        private Dictionary<Guid, List<UserRole>> db { get; set; }

        public UserRoleService(IServiceContext context) : base(context)
        {
            db = new Dictionary<Guid, List<UserRole>>();

            db.Add(This.Id, new List<UserRole>());

            Async.Execute(() => CreateUserRole(This.Id, "administrators", "System Administrators"));
            Async.Execute(() => CreateUserRole(This.Id, "users", "Normal Users"));
        }

        public async Task<List<UserRole>> GetUserRoles(Guid application)
        {
            var result = new List<UserRole>();

            await Task.Run(() =>
            {
                if (db.ContainsKey(application))
                    result.AddRange(db[application]);
            });

            return result;
        }

        public async Task<Guid> CreateUserRole(Guid application, string name, string description)
        {
            var result = Guid.Empty;

            await Task.Run(() =>
            {
                if (db.ContainsKey(application))
                {
                    var id = Guid.NewGuid();

                    db[application].Add(new UserRole()
                    {
                        Id = id,
                        Application = application,
                        Name = name,
                        Description = description
                    });

                    result = id;
                }
            });

            return result;
        }

        public async Task<bool> UpdateUserRole(Guid application, Guid id, string name, string description)
        {
            var result = false;

            await Task.Run(() =>
            {
                if (db.ContainsKey(application))
                {
                    var entity = db[application].FirstOrDefault(i => i.Id.Equals(id));

                    if (entity != null)
                    {
                        entity.Name = name;
                        entity.Description = description;

                        result = true;
                    }
                }
            });

            return result;
        }

        public async Task<bool> DeleteUserRole(Guid application, Guid id)
        {
            var result = false;

            await Task.Run(() =>
            {
                if (db.ContainsKey(application))
                {
                    var entity = db[application].FirstOrDefault(i => i.Id.Equals(id));

                    if (entity != null)
                    {
                        db[application].Remove(entity);

                        result = true;
                    }
                }
            });

            return result;
        }
    }
}