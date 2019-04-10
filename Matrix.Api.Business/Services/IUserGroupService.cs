using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Matrix.Agent.Directory.Model;
using Matrix.Framework.Business;

namespace Matrix.Api.Business.Services
{
    public interface IUserGroupService : IService
    {
        Task<List<UserGroup>> GetUserGroups(Guid application);
    }
}