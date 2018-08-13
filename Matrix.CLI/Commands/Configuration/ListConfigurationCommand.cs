using Matrix.CLI.Business.Services;

namespace Matrix.CLI.Commands.Configuration
{
    public class ListConfigurationCommand : Command
    {
        public ListConfigurationCommand(ITargetService targets)
            : base(targets, "lists configuration settings of an application")
        {
        }

        protected override object Execute()
        {
            object result = null;

            return result;
        }
    }
}