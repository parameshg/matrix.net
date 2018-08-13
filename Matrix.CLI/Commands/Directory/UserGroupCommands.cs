using System;
using Matrix.CLI.Business.Services;
using Microsoft.Extensions.CommandLineUtils;

namespace Matrix.CLI.Commands.Directory
{
    public class UserGroupCommands
    {
        private ITargetService Targets { get; }

        public UserGroupCommands(ITargetService targets)
        {
            Targets = targets ?? throw new ArgumentNullException(nameof(targets));
        }

        public void Register(CommandLineApplication cmd)
        {
            cmd.HelpOption("-? | -h | --help");
            cmd.Description = "manage user groups";

            cmd.Command("ls", new ListUserGroupCommand(Targets).Execute);

            cmd.OnExecute(() =>
            {
                cmd.ShowHelp("group");
                return 0;
            });
        }
    }
}