using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using System;

namespace MonthlyExpenses
{
    public class Program
    {
        public static void Main(string[] args)
        {
            BuildWebHost(args).Run();
        }

        public static IWebHost BuildWebHost(string[] args)
        {
            return WebHost.CreateDefaultBuilder(args)
                .ConfigureAppConfiguration((context, config) =>
                {
                    var env = context.HostingEnvironment;

                    config
                        //.AddJsonFile($"{AppContext.BaseDirectory}hostsettings.json", optional: false, reloadOnChange: true)
                        //.AddJsonFile($"{AppContext.BaseDirectory}hostsettings.{env.EnvironmentName}.json", optional: true, reloadOnChange: true)
                        .AddJsonFile($"{AppContext.BaseDirectory}globalsettings.json", optional: false, reloadOnChange: true)
                        .AddJsonFile($"{AppContext.BaseDirectory}globalsettings.{env.EnvironmentName}.json", optional: true, reloadOnChange: true);

                    Api.Startup.AdditionalConfiguration(config, env);
                })
                .UseStartup<Api.Startup>()
                .Build();
        }
    }
}
