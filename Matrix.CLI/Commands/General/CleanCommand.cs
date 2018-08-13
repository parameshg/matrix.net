using Matrix.CLI.Business.Services;

namespace Matrix.CLI.Commands.General
{
    public class CleanCommand : Command
    {
        public CleanCommand(ITargetService targets)
            : base(targets, "clean system")
        {
        }

        protected override object Execute()
        {
            object result = null;

            return result;
        }
    }
}