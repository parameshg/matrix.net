using Matrix.CLI.Business.Services;

namespace Matrix.CLI.Commands.Registry
{
    public class ListApplicationCommand : Command
    {
        public ListApplicationCommand(ITargetService targets)
            : base(targets, "lists application registered in the platform")
        {
        }

        protected override object Execute()
        {
            object result = null;

            return result;
        }
    }
}