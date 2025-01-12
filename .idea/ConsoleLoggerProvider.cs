using Microsoft.Extensions.Logging;
namespace DefaultNamespace;

public class ConsoleLoggerProvider : ILoggerProvider
{
    public ILogger CreateLogger(string categoryName)
    {
        return new ConsoleLogger(categoryName); // face un console logger pt fiecare instanta
    }

    public void Dispose()
    {
        // nu avem resurse pt dispose deci il las gol
    }
}