using Microsoft.Extensions.Logging;

public class ConsoleLogger : ILogger
{
    private readonly string _categoryName;

    public ConsoleLogger(string categoryName)
    {
        _categoryName = categoryName;
    }

    public IDisposable BeginScope<TState>(TState state)
    {
        return null; //cel mai probabil ramane pe null
    }

    public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter)
    {
        var message = formatter(state, exception); // primeste mesajul de log
        switch (logLevel)
        {
            case LogLevel.Information:
                LogInfo(message);
                break;
            case LogLevel.Error:
                LogError(message);
                break;
            case LogLevel.Warning:
                LogWarning(message);
                break;
            default:
                Log(message); 
                break;
        }
    }

    // Metoda Custom Log pt mesaje generale
    private void Log(string message)
    {
        Console.WriteLine($"[LOG] {_categoryName}: {message}");
    }

    // pt erori
    private void LogError(string message)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine($"[ERROR] {_categoryName}: {message}");
        Console.ResetColor();
    }

    // pt info
    private void LogInfo(string message)
    {
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine($"[INFO] {_categoryName}: {message}");
        Console.ResetColor();
    }

    // atentionari
    private void LogWarning(string message)
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine($"[WARNING] {_categoryName}: {message}");
        Console.ResetColor();
    }

    // IsEnabled verifica daca o metoda de log e enabled
    public bool IsEnabled(LogLevel logLevel)
    {
        // da enable la toate modurile de log
        return true;
    }
}