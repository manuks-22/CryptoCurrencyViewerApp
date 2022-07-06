using NLog;
using System;
using System.IO;
using System.Reflection;

namespace CryptoCurrencyApp.Infrastructure.Logging
{
    public class LogManager : ILogManager
    {
        private static ILogger logger = NLog.LogManager.GetCurrentClassLogger();

        public LogManager()
        {
            string assemblyFolder = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            NLog.LogManager.LoadConfiguration(Path.Combine(assemblyFolder, "Logging", "NLog.config"));
        }

        public void Information(string message)
        {
            logger.Info(message);
        }

        public void Warning(string message)
        {
            logger.Warn(message);
        }

        public void Error(string message)
        {
            logger.Error(message);
        }

        public void Error(string message, Exception ex)
        {
            logger.Error($"{message}{Environment.NewLine}{ex.StackTrace}");
        }
    }
}
