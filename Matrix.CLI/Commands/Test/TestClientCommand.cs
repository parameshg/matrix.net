using System;
using Matrix.CLI.Business.Services;

namespace Matrix.CLI.Commands.Test
{
    public class TestClientCommand : Command
    {
        public ITestService Server { get; }

        public TestClientCommand(ITargetService targets, ITestService server)
            : base(targets, "test platform")
        {
            Server = server ?? throw new ArgumentNullException(nameof(server));
        }

        protected override object Execute()
        {
            object result = null;

            return result;
        }
    }
}