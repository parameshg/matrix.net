using Matrix.CLI.Business.Services;

namespace Matrix.CLI.Commands.Registry
{
    public class ListLogCommand : Command
    {
        public ListLogCommand(ITargetService targets)
            : base(targets, "lists application logs")
        {
        }

        protected override object Execute()
        {
            object result = null;

            return result;
        }
    }
}