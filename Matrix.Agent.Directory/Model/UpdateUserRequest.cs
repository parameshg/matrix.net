using Matrix.Framework.Api.Model;

namespace Matrix.Agent.Directory.Model
{
    public class UpdateUserRequest : PutRequest
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }
    }
}