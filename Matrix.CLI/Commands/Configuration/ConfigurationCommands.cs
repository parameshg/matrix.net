using System;
using Matrix.CLI.Business.Services;
using Microsoft.Extensions.CommandLineUtils;

namespace Matrix.CLI.Commands.Configuration
{
    public class ConfigurationCommands
    {
        private ITargetService Targets { get; }

        public ConfigurationCommands(ITargetService targets)
        {
            Targets = targets ?? throw new ArgumentNullException(nameof(targets));
        }

        public void Register(CommandLineApplication cmd)
        {
            cmd.HelpOption("-? | -h | --help");
            cmd.Description = "manage configuration";

            cmd.Command("ls", new ListConfigurationCommand(Targets).Execute);

            cmd.OnExecute(() =>
            {
                cmd.ShowHelp("config");
                return 0;
            });
        }
    }
}