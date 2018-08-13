using System;
using Matrix.CLI.Business.Services;
using Microsoft.Extensions.CommandLineUtils;

namespace Matrix.CLI.Commands.Target
{
    public class TargetCommands
    {
        public ITargetService Server { get; }

        public TargetCommands(ITargetService server)
        {
            Server = server ?? throw new ArgumentNullException(nameof(server));
        }

        public void Register(CommandLineApplication cmd)
        {
            cmd.HelpOption("-? | -h | --help");
            cmd.Description = "manage targets";

            cmd.Command("register", new RegisterCommand(Server).Execute);

            cmd.OnExecute(() =>
            {
                cmd.ShowHelp("target");
                return 0;
            });
        }
    }
}