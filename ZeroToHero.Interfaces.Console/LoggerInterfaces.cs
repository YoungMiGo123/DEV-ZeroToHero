namespace ZeroToHero.Interfaces.Console
{
    using System;

    public class LoggerInterfaces
    {
        public interface ILogger
        {
            void LogMessage(string message);
        }
        public class FileLogger : ILogger
        {
            public void LogMessage(string message)
            {
                // Implement logic to log messages to a file
                Console.WriteLine($"Logging to file: {message}");
            }
        }
        public class DatabaseLogger : ILogger
        {
            public void LogMessage(string message)
            {
                // Implement logic to log messages to a database
                Console.WriteLine($"Logging to database: {message}");
            }
        }

        public static void BuildLoggerExample()
        {
            ILogger logger = new FileLogger();
            logger.LogMessage("This is a log message.");

            logger = new DatabaseLogger();
            logger.LogMessage("This is a log message.");
        }
    }
}
