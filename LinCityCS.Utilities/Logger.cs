using System;
using System.IO;
using System.Text;

namespace LinCityCS.Utilities
{
    /// <summary>
    /// Provides logging functionality for the game.
    /// </summary>
    public static class Logger
    {
        private static string logFilePath;
        private static bool isInitialized;
        private static object lockObject = new object();

        /// <summary>
        /// Initializes the logger.
        /// </summary>
        /// <param name="logFilePath">The path to the log file.</param>
        public static void Initialize(string logFilePath)
        {
            lock (lockObject)
            {
                Logger.logFilePath = logFilePath;
                isInitialized = true;

                // Create the log file directory if it doesn't exist
                string logDirectory = Path.GetDirectoryName(logFilePath);
                if (!string.IsNullOrEmpty(logDirectory) && !Directory.Exists(logDirectory))
                {
                    Directory.CreateDirectory(logDirectory);
                }

                // Clear the log file
                File.WriteAllText(logFilePath, string.Empty);

                // Write the initial log entry
                Log(LogLevel.Info, "Logger initialized");
            }
        }

        /// <summary>
        /// Logs a message.
        /// </summary>
        /// <param name="level">The log level.</param>
        /// <param name="message">The message to log.</param>
        public static void Log(LogLevel level, string message)
        {
            lock (lockObject)
            {
                if (!isInitialized)
                {
                    Console.WriteLine($"[{level}] {message}");
                    return;
                }

                try
                {
                    string logEntry = $"[{DateTime.Now:yyyy-MM-dd HH:mm:ss}] [{level}] {message}";
                    
                    // Write to the log file
                    using (StreamWriter writer = new StreamWriter(logFilePath, true, Encoding.UTF8))
                    {
                        writer.WriteLine(logEntry);
                    }
                    
                    // Also write to the console
                    Console.WriteLine(logEntry);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error writing to log file: {ex.Message}");
                }
            }
        }

        /// <summary>
        /// Logs an error message.
        /// </summary>
        /// <param name="message">The message to log.</param>
        public static void Error(string message)
        {
            Log(LogLevel.Error, message);
        }

        /// <summary>
        /// Logs a warning message.
        /// </summary>
        /// <param name="message">The message to log.</param>
        public static void Warning(string message)
        {
            Log(LogLevel.Warning, message);
        }

        /// <summary>
        /// Logs an info message.
        /// </summary>
        /// <param name="message">The message to log.</param>
        public static void Info(string message)
        {
            Log(LogLevel.Info, message);
        }

        /// <summary>
        /// Logs a debug message.
        /// </summary>
        /// <param name="message">The message to log.</param>
        public static void Debug(string message)
        {
            Log(LogLevel.Debug, message);
        }
    }

    /// <summary>
    /// Represents a log level.
    /// </summary>
    public enum LogLevel
    {
        /// <summary>
        /// Error log level.
        /// </summary>
        Error,
        
        /// <summary>
        /// Warning log level.
        /// </summary>
        Warning,
        
        /// <summary>
        /// Info log level.
        /// </summary>
        Info,
        
        /// <summary>
        /// Debug log level.
        /// </summary>
        Debug
    }
}
