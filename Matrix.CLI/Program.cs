using System;
using Matrix.CLI.Business.Services;
using Matrix.CLI.Commands.Configuration;
using Matrix.CLI.Commands.Directory;
using Matrix.CLI.Commands.General;
using Matrix.CLI.Commands.Registry;
using Matrix.CLI.Commands.Target;
using Matrix.CLI.Database.Repositories;
using Microsoft.Extensions.CommandLineUtils;

namespace Matrix.CLI
{
    public class Program
    {
        private static ITargetService Targets { get; set; }

        static Program()
        {
            Targets = new TargetService(new TargetRepository());
        }

        public static void Main(string[] args)
        {
            var app = new CommandLineApplication(throwOnUnexpectedArg: true);

            try
            {
                app.Name = "mx";
                app.Description = "Matrix Command-line Interface";
                app.HelpOption("-? | -h | --help");

                app.Command("system", new GeneralCommands(Targets).Register);
                app.Command("target", new TargetCommands(Targets).Register);
                app.Command("app", new ApplicationCommands(Targets).Register);
                app.Command("config", new ConfigurationCommands(Targets).Register);
                app.Command("user", new UserCommands(Targets).Register);
                app.Command("log", new LogCommands(Targets).Register);

                app.OnExecute(() =>
                {
                    app.ShowHelp("mx");
                    return 0;
                });

                app.Execute(args);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);

                while (e.InnerException != null)
                {
                    Console.WriteLine(e.InnerException.Message);
                    e = e.InnerException;
                }

                app.ShowHelp();
            }
        }
    }
}