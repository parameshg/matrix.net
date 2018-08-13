using System;
using Matrix.CLI.Business.Services;
using Microsoft.Extensions.CommandLineUtils;

namespace Matrix.CLI.Commands.Registry
{
    public class ApplicationCommands
    {
        private ITargetService Targets { get; }

        public ApplicationCommands(ITargetService targets)
        {
            Targets = targets ?? throw new ArgumentNullException(nameof(targets));
        }

        public void Register(CommandLineApplication cmd)
        {
            cmd.HelpOption("-? | -h | --help");
            cmd.Description = "manage applications";

            cmd.Command("ls", new ListApplicationCommand(Targets).Execute);

            cmd.OnExecute(() =>
            {
                cmd.ShowHelp("app");
                return 0;
            });
        }
    }
}