namespace DefaultNamespace;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

class Program
{
    public static void Main(string[] args)
    {
        var host = Host.CreateDefaultBuilder(args)
         .ConfigureServices((context, services) =>
         {
             services.AddSingleton<IAplicatiaPrincipala, AplicatiaPrincipala>();
         })
         .ConfigureLogging((context, logging) =>
         {
             // Remove default logging providers
             logging.ClearProviders();

             // Add your custom logger provider
             logging.AddProvider(new ConsoleLoggerProvider());
         })
         .Build();

        // Run the application
        var app = host.Services.GetRequiredService<IAplicatiaPrincipala>();
        app.Run();
    }
}
