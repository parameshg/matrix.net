using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Matrix.Agent.Directory.Model;
using Matrix.Framework.Database;
using PowerMapper;

namespace Matrix.Agent.Directory.Database.Repositories
{
    public class UserGroupRepository : Repository, IUserGroupRepository
    {
        private readonly DirectoryDbContext db;

        public UserGroupRepository(IRepositoryContext context, DirectoryDbContext database)
            : base(context)
        {
            db = database;
        }

        public async Task<List<UserGroup>> GetUserGroups(Guid application)
        {
            var result = new List<UserGroup>();

            await Task.Run(() =>
            {
                result.AddRange(Mapper.Map<List<Entities.UserGroup>, List<UserGroup>>(db.UserGroups.ToList()));
            });

            return result;
        }

        public async Task<UserGroup> GetUserGroupById(Guid id)
        {
            UserGroup result = null;

            await Task.Run(() =>
            {
                result = Mapper.Map<Entities.UserGroup, UserGroup>(db.UserGroups.FirstOrDefault(i => i.Id.Equals(id)));
            });

            return result;
        }

        public async Task<UserGroup> GetUserGroupByName(Guid application, string name)
        {
            UserGroup result = null;

            await Task.Run(() =>
            {
                result = Mapper.Map<Entities.UserGroup, UserGroup>(db.UserGroups.FirstOrDefault(i => i.Application.Equals(application) && i.Name.Equals(name)));
            });

            return result;
        }

        public async Task<Guid> CreateUserGroup(Guid application, string name, string description)
        {
            var result = Guid.Empty;

            var id = Guid.NewGuid();

            await db.UserGroups.AddAsync(new Entities.UserGroup()
            {
                Id = id,
                Application = application,
                Name = name,
                Description = description
            });

            if (await db.SaveChangesAsync() > 0)
                result = id;

            return result;
        }

        public async Task<bool> UpdateUserGroup(Guid id, string name, string description)
        {
            var result = false;

            var entity = db.UserGroups.FirstOrDefault(i => i.Id.Equals(id));

            if (entity != null)
            {
                entity.Name = name;
                entity.Description = description;
            }

            result = await db.SaveChangesAsync() > 0;

            return result;
        }

        public async Task<bool> DeleteUserGroup(Guid id)
        {
            var result = false;

            db.UserGroups.Remove(db.UserGroups.FirstOrDefault(i => i.Id.Equals(id)));

            result = await db.SaveChangesAsync() > 0;

            return result;
        }
    }
}