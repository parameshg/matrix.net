using Matrix.CLI.Business.Services;

namespace Matrix.CLI.Commands.Directory
{
    public class ListUserCommand : Command
    {
        public ListUserCommand(ITargetService targets)
            : base(targets, "lists users registered in the platform")
        {
        }

        protected override object Execute()
        {
            object result = null;

            return result;
        }
    }
}