namespace Utilities.Logger
{
    using Microsoft.Extensions.Logging;

    public class LoggerGNB<T> : ILoggerGNB<T>
    {
        private readonly ILogger<T> _logger;

        public LoggerGNB(ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger<T>();
        }

        public void LogInformation(string message, params object[] args)
        {
            _logger.LogInformation(message, args);
        }

        public void LogWarning(string message, params object[] args)
        {
            _logger.LogWarning(message, args);
        }

        public void LogError(string message, params object[] args)
        {
            _logger.LogError(message, args);
        }
    }
}
