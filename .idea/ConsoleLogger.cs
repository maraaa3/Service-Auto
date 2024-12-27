namespace DefaultNamespace;

public class ConsoleLogger:ILogger
{
    public void Log(string message)
    {
        Console.WriteLine($"[LOG] {DateTime.Now}: {message}");
    }
}