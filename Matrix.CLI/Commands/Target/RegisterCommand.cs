using Matrix.CLI.Business.Services;
using Matrix.Threading;
using Microsoft.Extensions.CommandLineUtils;

namespace Matrix.CLI.Commands.Target
{
    public class RegisterCommand : Command
    {
        private CommandOption _url;

        protected string Url { get { return _url != null && _url.HasValue() ? _url.Value() : string.Empty; } }

        private CommandOption _alias;

        protected string Alias { get { return _alias != null && _alias.HasValue() ? _alias.Value() : string.Empty; } }

        private ITargetService Server { get; }

        public RegisterCommand(ITargetService targets)
            : base(targets, "register command target")
        {
            Server = targets ?? throw new System.ArgumentNullException(nameof(targets));
        }

        protected override void Register(CommandLineApplication cmd)
        {
            _url = cmd.Option("--url | -u", "url of the target", CommandOptionType.SingleValue);
            _alias = cmd.Option("--alias | -a", "alias of the target", CommandOptionType.SingleValue);
        }

        protected override object Execute()
        {
            object result = null;

            if (!string.IsNullOrEmpty(Alias) && !string.IsNullOrEmpty(Url))
            {
                if (Async.Execute(() => Server.SaveTarget(Alias, Url)))
                    result = new { message = "target saved" };
            }

            return result;
        }
    }
}