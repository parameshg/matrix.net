using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Matrix.Agent.Directory.Model;
using Matrix.Api.Business.Services;
using Matrix.Framework.Business;

namespace Matrix.Api.Business.Stub
{
    public class UserService : Service, IUserService
    {
        private Dictionary<Guid, List<User>> db { get; set; }

        public UserService(IServiceContext context)
            : base(context)
        {
            db = new Dictionary<Guid, List<User>>();
        }

        public async Task<List<User>> GetUsers(Guid application)
        {
            var result = new List<User>();

            await Task.Run(() =>
            {
                if (db.ContainsKey(application))
                {
                    result.AddRange(db[application]);
                }
            });

            return result;
        }

        public async Task<User> GetUserById(Guid application, Guid id)
        {
            User result = null;

            await Task.Run(() =>
            {
                if (db.ContainsKey(application))
                {
                    result = db[application].FirstOrDefault(i => i.Id.Equals(id));
                }
            });

            return result;
        }

        public async Task<User> GetUserByUsername(Guid application, string username)
        {
            User result = null;

            await Task.Run(() =>
            {
                if (db.ContainsKey(application))
                {
                    result = db[application].FirstOrDefault(i => i.Username.Equals(username));
                }
            });

            return result;
        }

        public async Task<bool> UpdateUserPassword(Guid id, string password)
        {
            var result = false;

            await Task.Run(() =>
            {
                result = true;
            });

            return result;
        }

        public async Task<bool> UpdateUserProfile(Guid application, Guid id, string firstName, string lastName, string email, string phone)
        {
            var result = false;

            await Task.Run(() =>
            {
                if (db.ContainsKey(application))
                {
                    var entity = db[application].FirstOrDefault(i => i.Id.Equals(id));

                    if (entity != null)
                    {
                        entity.FirstName = firstName;
                        entity.LastName = lastName;
                        entity.Email = email;
                        entity.Phone = phone;

                        result = true;
                    }
                }
            });

            return result;
        }
    }
}