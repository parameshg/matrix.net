using System;
using Matrix.CLI.Business.Services;
using Microsoft.Extensions.CommandLineUtils;

namespace Matrix.CLI.Commands.Directory
{
    public class UserRoleCommands
    {
        private ITargetService Targets { get; }

        public UserRoleCommands(ITargetService targets)
        {
            Targets = targets ?? throw new ArgumentNullException(nameof(targets));
        }

        public void Register(CommandLineApplication cmd)
        {
            cmd.HelpOption("-? | -h | --help");
            cmd.Description = "manage user roles";

            cmd.Command("ls", new ListUserRoleCommand(Targets).Execute);

            cmd.OnExecute(() =>
            {
                cmd.ShowHelp("role");
                return 0;
            });
        }
    }
}