using Matrix.CLI.Business.Services;

namespace Matrix.CLI.Commands.General
{
    public class GetErrorCommand : Command
    {
        public GetErrorCommand(ITargetService targets)
            : base(targets, "get last error")
        {
        }

        protected override object Execute()
        {
            object result = null;

            return result;
        }
    }
}