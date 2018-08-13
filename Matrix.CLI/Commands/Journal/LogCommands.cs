using System;
using Matrix.CLI.Business.Services;
using Microsoft.Extensions.CommandLineUtils;

namespace Matrix.CLI.Commands.Registry
{
    public class LogCommands
    {
        private ITargetService Targets { get; }

        public LogCommands(ITargetService targets)
        {
            Targets = targets ?? throw new ArgumentNullException(nameof(targets));
        }

        public void Register(CommandLineApplication cmd)
        {
            cmd.HelpOption("-? | -h | --help");
            cmd.Description = "manage application logs";

            cmd.Command("ls", new ListLogCommand(Targets).Execute);

            cmd.OnExecute(() =>
            {
                cmd.ShowHelp("log");
                return 0;
            });
        }
    }
}