using System.IO;
using AzureKeyVaultAspNetCore.Settings;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;

namespace AzureKeyVaultAspNetCore
{
    public class Program
    {
        public static void Main(string[] args)
        {
            BuildWebHost(args).Run();
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .ConfigureAppConfiguration((context, config) =>
                {
                    config.SetBasePath(Directory.GetCurrentDirectory())
                        .AddJsonFile("appsettings.json", optional: false)
                        .AddEnvironmentVariables();

                    var builtConfig = config.Build();
                    var settings = builtConfig.GetSection("KeyVault").Get<KeyVaultSettings>();


                    config.AddAzureKeyVault(
                        settings.Vault, settings.ClientId, settings.ClientSecret);

                })
                .UseStartup<Startup>()
                .Build();
    }
}
