using Matrix.Framework.Api.Model;

namespace Matrix.Agent.Directory.Model
{
    public class CreateUserRequest : PostRequest
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }
    }
}