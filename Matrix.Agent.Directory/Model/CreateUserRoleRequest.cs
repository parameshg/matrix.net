using Matrix.Framework.Api.Model;

namespace Matrix.Agent.Directory.Model
{
    public class CreateUserRoleRequest : PostRequest
    {
        public string Name { get; set; }

        public string Description { get; set; }
    }
}