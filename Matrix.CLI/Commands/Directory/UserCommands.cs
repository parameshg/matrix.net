using System;
using Matrix.CLI.Business.Services;
using Microsoft.Extensions.CommandLineUtils;

namespace Matrix.CLI.Commands.Directory
{
    public class UserCommands
    {
        private ITargetService Targets { get; }

        public UserCommands(ITargetService targets)
        {
            Targets = targets ?? throw new ArgumentNullException(nameof(targets));
        }

        public void Register(CommandLineApplication cmd)
        {
            cmd.HelpOption("-? | -h | --help");
            cmd.Description = "manage users";

            cmd.Command("ls", new ListUserCommand(Targets).Execute);

            cmd.Command("group", new UserGroupCommands(Targets).Register);
            cmd.Command("role", new UserRoleCommands(Targets).Register);

            cmd.OnExecute(() =>
            {
                cmd.ShowHelp("user");
                return 0;
            });
        }
    }
}