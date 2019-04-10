using Matrix.Agent.Directory.Database.Converters;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using PowerMapper;

namespace Matrix.Agent.Directory
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Mapper.RegisterConverter<Model.User, Database.Entities.User>(new UserConverter().ConvertToEntity);
            Mapper.RegisterConverter<Database.Entities.User, Model.User>(new UserConverter().ConvertToModel);

            var host = new WebHostBuilder();
            host.UseKestrel();
            host.UseContentRoot(System.IO.Directory.GetCurrentDirectory());

            host.ConfigureAppConfiguration((context, configuration) =>
            {
                var environment = context.HostingEnvironment;

                configuration.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
                configuration.AddJsonFile($"appsettings.{environment.EnvironmentName}.json", optional: true, reloadOnChange: true);
                configuration.AddJsonFile($"/run/secrets/appsettings_shared.json", optional: true, reloadOnChange: true);
                configuration.AddJsonFile($"/run/secrets/appsettings_directory.json", optional: true, reloadOnChange: true);
                configuration.AddEnvironmentVariables();
            });

            host.ConfigureLogging((context, logging) =>
            {
                logging.AddConfiguration(context.Configuration.GetSection("Logging"));
                logging.AddConsole();
                logging.AddDebug();
            });

            host.UseStartup<Startup>();
            host.Build().Run();
        }
    }
}