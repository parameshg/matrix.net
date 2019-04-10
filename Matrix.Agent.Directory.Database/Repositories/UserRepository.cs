using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Matrix.Agent.Directory.Model;
using Matrix.Framework.Database;
using PowerMapper;

namespace Matrix.Agent.Directory.Database.Repositories
{
    public class UserRepository : Repository, IUserRepository
    {
        private readonly DirectoryDbContext db;

        public UserRepository(IRepositoryContext context, DirectoryDbContext database)
            : base(context)
        {
            db = database;
        }

        public async Task<List<User>> GetUsers(Guid application)
        {
            var result = new List<User>();

            await Task.Run(() =>
            {
                result = Mapper.Map<List<Entities.User>, List<User>>(db.Users.Where(i => i.Application.Equals(application)).ToList());
            });

            return result;
        }

        public async Task<User> GetUserById(Guid id)
        {
            User result = null;

            await Task.Run(() =>
            {
                result = Mapper.Map<Entities.User, User>(db.Users.FirstOrDefault(i => i.Id.Equals(id)));
            });

            return result;
        }

        public async Task<User> GetUserByUsername(Guid application, string username)
        {
            User result = null;

            await Task.Run(() =>
            {
                result = Mapper.Map<Entities.User, User>(db.Users.FirstOrDefault(i => i.Application.Equals(application) && i.Username.Equals(username)));
            });

            return result;
        }

        public async Task<Guid> CreateUser(Guid application, string firstName, string lastName, string username, string password, string email, string phone)
        {
            var result = Guid.Empty;

            var id = Guid.NewGuid();

            await db.Users.AddAsync(new Entities.User()
            {
                Id = id,
                Application = application,
                Username = username,
                Password = password,
                FirstName = firstName,
                LastName = lastName,
                Email = email,
                Phone = phone
            });

            if (await db.SaveChangesAsync() > 0)
            {
                result = id;
            }

            return result;
        }

        public async Task<bool> UpdateUserProfile(Guid id, string firstName, string lastName, string email, string phone)
        {
            var result = false;

            var entity = db.Users.FirstOrDefault(i => i.Id.Equals(id));

            if (entity != null)
            {
                entity.FirstName = firstName;
                entity.LastName = lastName;
                entity.Email = email;
                entity.Phone = phone;
            }

            result = await db.SaveChangesAsync() > 0;

            return result;
        }

        public async Task<bool> UpdateUserPassword(Guid id, string password)
        {
            var result = false;

            var entity = db.Users.FirstOrDefault(i => i.Id.Equals(id));

            if (entity != null)
            {
                entity.Password = password;
            }

            result = await db.SaveChangesAsync() > 0;

            return result;
        }

        public async Task<bool> DeleteUser(Guid id)
        {
            var result = false;

            db.Users.Remove(db.Users.FirstOrDefault(i => i.Id.Equals(id)));

            result = await db.SaveChangesAsync() > 0;

            return result;
        }

        public async Task<bool> AddUserRoles(Guid userId, params Guid[] roles)
        {
            var result = false;

            var entity = db.Users.FirstOrDefault(i => i.Id.Equals(userId));

            if (entity != null)
            {
                var mappings = new List<Entities.UserRoleMapping>();

                foreach (var roleId in roles)
                {
                    mappings.Add(new Entities.UserRoleMapping()
                    {
                        UserId = userId,
                        RoleId = roleId
                    });
                }

                entity.UserRoleMappings.AddRange(mappings);
            }

            result = await db.SaveChangesAsync() > 0;

            return result;
        }

        public async Task<bool> RemoveUserRoles(Guid userId, params Guid[] roles)
        {
            var result = false;

            var entity = db.Users.FirstOrDefault(i => i.Id.Equals(userId));

            if (entity != null)
            {
                for (int i = 0; i < entity.UserRoleMappings.Count; i++)
                {
                    if (roles.Contains(entity.UserRoleMappings[i].RoleId))
                    {
                    }
                }
            }

            result = await db.SaveChangesAsync() > 0;

            return result;
        }

        public async Task<bool> AddUserGroups(Guid userId, params Guid[] groups)
        {
            var result = false;

            var entity = db.Users.FirstOrDefault(i => i.Id.Equals(userId));

            if (entity != null)
            {
                var mappings = new List<Entities.UserGroupMapping>();

                foreach (var groupId in groups)
                {
                    mappings.Add(new Entities.UserGroupMapping()
                    {
                        UserId = userId,
                        GroupId = groupId
                    });
                }

                entity.UserGroupMappings.AddRange(mappings);
            }

            result = await db.SaveChangesAsync() > 0;

            return result;
        }

        public async Task<bool> RemoveUserGroups(Guid userId, params Guid[] groups)
        {
            var result = false;

            var entity = db.Users.FirstOrDefault(i => i.Id.Equals(userId));

            if (entity != null)
            {
                result = await db.SaveChangesAsync() > 0;
            }

            return result;
        }
    }
}