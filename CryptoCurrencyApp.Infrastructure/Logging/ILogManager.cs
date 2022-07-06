using System;

namespace CryptoCurrencyApp.Infrastructure.Logging
{
    /// <summary>
    /// Log manager.
    /// </summary>
    public interface ILogManager
    {
        /// <summary>
        /// Logs information.
        /// </summary>
        /// <param name="message">The message to log.</param>
        void Information(string message);

        /// <summary>
        /// Logs warning.
        /// </summary>
        /// <param name="message">The message to log.</param>
        void Warning(string message);

        /// <summary>
        /// Logs error.
        /// </summary>
        /// <param name="message">The message to log.</param>
        void Error(string message);

        /// <summary>
        /// Logs error with exception details.
        /// </summary>
        /// <param name="message">The message to log.</param>
        /// <param name="ex">Exception details</param>
        void Error(string message, Exception ex);
    }
}
