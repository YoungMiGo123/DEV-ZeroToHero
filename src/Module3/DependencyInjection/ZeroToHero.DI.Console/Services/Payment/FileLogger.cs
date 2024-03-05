namespace ZeroToHero.DI.Console.Services.Payment;
using System;

// Implementation of ILogger using a file logger
public class FileLogger : ILogger
{
    public void Log(string message)
    {
        // Code to log message to a file
        Console.WriteLine($"[File Logger] {message}");
    }
}
