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
    public class UserService : Service, IUserService
    {
        private Dictionary<Guid, List<User>> db { get; set; }

        public UserService(IServiceContext context)
            : base(context)
        {
            db = new Dictionary<Guid, List<User>>();

            db.Add(This.Id, new List<User>());

            Async.Execute(() => CreateUser(This.Id, Neo.FirstName, Neo.LastName, Neo.Username, Neo.Password, Neo.Email, Neo.Phone));
        }

        public async Task<List<User>> GetUsers(Guid application)
        {
            var result = new List<User>();

            await Task.Run(() =>
            {
                if (db.ContainsKey(application))
                    result.AddRange(db[application]);
            });

            return result;
        }

        public async Task<User> GetUserById(Guid application, Guid id)
        {
            User result = null;

            await Task.Run(() =>
            {
                if (db.ContainsKey(application))
                    result = db[application].FirstOrDefault(i => i.Id.Equals(id));
            });

            return result;
        }

        public async Task<User> GetUserByUsername(Guid application, string username)
        {
            User result = null;

            await Task.Run(() =>
            {
                if (db.ContainsKey(application))
                    result = db[application].FirstOrDefault(i => i.Username.Equals(username));
            });

            return result;
        }

        public async Task<Guid> CreateUser(Guid application, string firstName, string lastName, string username, string password, string email, string phone)
        {
            var result = Guid.Empty;

            await Task.Run(() =>
            {
                if (db.ContainsKey(application))
                {
                    var id = Guid.NewGuid();

                    db[application].Add(new User()
                    {
                        Id = id,
                        Application = application,
                        FirstName = firstName,
                        LastName = lastName,
                        Username = username,
                        Password = password,
                        Email = email,
                        Phone = phone
                    });

                    result = id;
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

        public async Task<bool> AddUserGroups(Guid userId, params Guid[] groups)
        {
            var result = false;

            await Task.Run(() =>
            {
                result = true;
            });

            return result;
        }

        public async Task<bool> AddUserRoles(Guid userId, params Guid[] roles)
        {
            var result = false;

            await Task.Run(() =>
            {
                result = true;
            });

            return result;
        }

        public async Task<bool> RemoveUserGroups(Guid userId, params Guid[] groups)
        {
            var result = false;

            await Task.Run(() =>
            {
                result = true;
            });

            return result;
        }

        public async Task<bool> RemoveUserRoles(Guid userId, params Guid[] roles)
        {
            var result = false;

            await Task.Run(() =>
            {
                result = true;
            });

            return result;
        }

        public async Task<bool> DeleteUser(Guid application, Guid id)
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