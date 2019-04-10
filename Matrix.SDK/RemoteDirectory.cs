using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Matrix.SDK.Model;

namespace Matrix.SDK
{
    public class RemoteDirectory : RemoteAgent
    {
        public Task<List<User>> GetUsers(Guid applicationId)
        {
            throw new NotImplementedException();
        }

        public Task<List<UserGroup>> GetUserGroups(Guid applicationId)
        {
            throw new NotImplementedException();
        }

        public Task<List<UserRole>> GetUserRoles(Guid applicationId)
        {
            throw new NotImplementedException();
        }
    }
}