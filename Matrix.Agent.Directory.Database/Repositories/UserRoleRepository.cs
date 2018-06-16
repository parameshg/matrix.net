using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Matrix.Agent.Directory.Model;
using Matrix.Framework.Database;
using PowerMapper;

namespace Matrix.Agent.Directory.Database.Repositories
{
    public class UserRoleRepository : Repository, IUserRoleRepository
    {
        private readonly DirectoryDbContext db;

        public UserRoleRepository(IRepositoryContext context, DirectoryDbContext database)
            : base(context)
        {
            db = database;
        }

        public async Task<List<UserRole>> GetUserRoles(Guid application)
        {
            var result = new List<UserRole>();

            await Task.Run(() =>
            {
                result.AddRange(Mapper.Map<List<Entities.UserRole>, List<UserRole>>(db.UserRoles.ToList()));
            });

            return result;
        }

        public async Task<UserRole> GetUserRoleById(Guid id)
        {
            UserRole result = null;

            await Task.Run(() =>
            {
                result = Mapper.Map<Entities.UserRole, UserRole>(db.UserRoles.FirstOrDefault(i => i.Id.Equals(id)));
            });

            return result;
        }

        public async Task<UserRole> GetUserRoleByName(Guid application, string name)
        {
            UserRole result = null;

            await Task.Run(() =>
            {
                result = Mapper.Map<Entities.UserRole, UserRole>(db.UserRoles.FirstOrDefault(i => i.Application.Equals(application) && i.Name.Equals(name)));
            });

            return result;
        }

        public async Task<Guid> CreateUserRole(Guid application, string name, string description)
        {
            var result = Guid.Empty;

            var id = Guid.NewGuid();

            await db.UserRoles.AddAsync(new Entities.UserRole()
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

        public async Task<bool> UpdateUserRole(Guid id, string name, string description)
        {
            var result = false;

            var entity = db.UserRoles.FirstOrDefault(i => i.Id.Equals(id));

            if (entity != null)
            {
                entity.Name = name;
                entity.Description = description;
            }

            result = await db.SaveChangesAsync() > 0;

            return result;
        }

        public async Task<bool> DeleteUserRole(Guid id)
        {
            var result = false;

            db.UserRoles.Remove(db.UserRoles.FirstOrDefault(i => i.Id.Equals(id)));

            result = await db.SaveChangesAsync() > 0;

            return result;
        }
    }
}