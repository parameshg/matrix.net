using Matrix.CLI.Business.Services;

namespace Matrix.CLI.Commands.Directory
{
    public class ListUserRoleCommand : Command
    {
        public ListUserRoleCommand(ITargetService targets)
            : base(targets, "lists user roles registered in the platform")
        {
        }

        protected override object Execute()
        {
            object result = null;

            return result;
        }
    }
}