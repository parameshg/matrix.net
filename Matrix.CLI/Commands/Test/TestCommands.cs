using System;
using Matrix.CLI.Business.Services;
using Microsoft.Extensions.CommandLineUtils;

namespace Matrix.CLI.Commands.Test
{
    public class TestCommands
    {
        public ITargetService Targets { get; }

        private ITestService Server { get; }

        public TestCommands(ITargetService targets, ITestService server)
        {
            Targets = targets ?? throw new ArgumentNullException(nameof(targets));

            Server = server ?? throw new ArgumentNullException(nameof(server));
        }

        public void Register(CommandLineApplication cmd)
        {
            cmd.HelpOption("-? | -h | --help");

            cmd.Description = "test platform";

            cmd.Command("clients", new TestClientCommand(Targets, Server).Execute);

            cmd.OnExecute(() =>
            {
                cmd.ShowHelp("app");
                return 0;
            });
        }
    }
}