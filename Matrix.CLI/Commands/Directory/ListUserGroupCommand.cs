using Matrix.CLI.Business.Services;

namespace Matrix.CLI.Commands.Directory
{
    public class ListUserGroupCommand : Command
    {
        public ListUserGroupCommand(ITargetService targets)
            : base(targets, "lists user groups registered in the platform")
        {
        }

        protected override object Execute()
        {
            object result = null;

            return result;
        }
    }
}