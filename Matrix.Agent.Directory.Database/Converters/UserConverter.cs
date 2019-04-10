using System.Collections.Generic;

namespace Matrix.Agent.Directory.Database.Converters
{
    public class UserConverter
    {
        public Model.User ConvertToModel(Entities.User entity)
        {
            var result = new Model.User();

            if (entity != null)
            {
                result.Id = entity.Id;
                result.Application = entity.Application;
                result.Username = entity.Username;
                result.FirstName = entity.FirstName;
                result.LastName = entity.LastName;
                result.Email = entity.Email;
                result.Phone = entity.Phone;

                if (entity.UserRoleMappings != null)
                {
                    foreach (var i in entity.UserRoleMappings)
                    {
                        result.Roles.Add(new Model.User.Role()
                        {
                            Id = i.Role.Id,
                            Name = i.Role?.Name,
                            Description = i.Role?.Description
                        });
                    }
                }

                if (entity.UserGroupMappings != null)
                {
                    foreach (var i in entity.UserGroupMappings)
                    {
                        result.Groups.Add(new Model.User.Group()
                        {
                            Id = i.Group.Id,
                            Name = i.Group?.Name,
                            Description = i.Group?.Description
                        });
                    }
                }
            }

            return result;
        }

        public Entities.User ConvertToEntity(Model.User model)
        {
            var result = new Entities.User();

            if (model != null)
            {
                result.Id = model.Id;
                result.Application = model.Application;
                result.Username = model.Username;
                result.FirstName = model.FirstName;
                result.LastName = model.LastName;
                result.Email = model.Email;
                result.Phone = model.Phone;

                if (model.Roles != null)
                {
                    result.UserRoleMappings = new List<Entities.UserRoleMapping>();

                    foreach (var i in model.Roles)
                    {
                        result.UserRoleMappings.Add(new Entities.UserRoleMapping()
                        {
                            UserId = model.Id,
                            RoleId = i.Id
                        });
                    }
                }

                if (model.Groups != null)
                {
                    result.UserGroupMappings = new List<Entities.UserGroupMapping>();

                    foreach (var i in model.Groups)
                    {
                        result.UserGroupMappings.Add(new Entities.UserGroupMapping()
                        {
                            UserId = model.Id,
                            GroupId = i.Id
                        });
                    }
                }
            }

            return result;
        }
    }
}