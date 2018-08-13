using System;
using Matrix.CLI.Business.Services;
using Matrix.Threading;
using Microsoft.Extensions.CommandLineUtils;
using Newtonsoft.Json;
using NLog;

namespace Matrix.CLI.Commands
{
    public abstract class Command
    {
        protected ILogger Logger { get; }

        protected ITargetService Targets { get; }

        protected string Description { get; }

        protected bool Verbose { get; private set; }

        protected bool Pretty { get; private set; }

        protected string Endpoint { get; private set; }

        public Command(ITargetService targets, string description)
        {
            Logger = LogManager.GetCurrentClassLogger();
            Targets = targets ?? throw new ArgumentNullException(nameof(targets));
            Description = description ?? throw new ArgumentNullException(nameof(description));
        }

        public void Execute(CommandLineApplication cmd)
        {
            cmd.HelpOption("-? | -h | --help");
            cmd.Description = Description;

            var pretty = cmd.Option("--pretty | -p", "pretty print json", CommandOptionType.NoValue);
            var verbose = cmd.Option("--verbose | -v", "verbose execution", CommandOptionType.NoValue);
            var target = cmd.Option("--target | -t", "target", CommandOptionType.SingleValue);

            Register(cmd);

            cmd.OnExecute(() =>
            {
                Pretty = pretty.HasValue();
                Verbose = verbose.HasValue();
                Endpoint = Async.Execute(() => Targets.GetTarget(target.Value()))?.Url;

                try
                {
                    var response = Execute();

                    if (response != null)
                        Print(response);
                    else
                        throw new Exception("response is null");
                }
                catch (Exception e)
                {
                    Print(new { error = e.Message });
                }

                return 0;
            });
        }

        protected abstract object Execute();

        protected virtual void Register(CommandLineApplication cmd) { }

        protected void Print(object o)
        {
            Console.WriteLine(JsonConvert.SerializeObject(o, Pretty ? Formatting.Indented : Formatting.None));
        }

        private string GetCurrentTarget()
        {
            var result = string.Empty;



            return result;
        }
    }
}