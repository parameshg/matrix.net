using System;
using Matrix.CLI.Business.Services;
using Microsoft.Extensions.CommandLineUtils;

namespace Matrix.CLI.Commands.General
{
    public class GeneralCommands
    {
        private ITargetService Targets { get; }

        public GeneralCommands(ITargetService targets)
        {
            Targets = targets ?? throw new ArgumentNullException(nameof(targets));
        }

        public void Register(CommandLineApplication cmd)
        {
            cmd.HelpOption("-? | -h | --help");
            cmd.Description = "manage system";

            cmd.Command("clean", new CleanCommand(Targets).Execute);
            cmd.Command("error", new GetErrorCommand(Targets).Execute);

            cmd.OnExecute(() =>
            {
                cmd.ShowHelp("system");
                return 0;
            });
        }
    }
}