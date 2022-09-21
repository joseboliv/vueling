namespace Utilities.Logger
{
    public interface ILoggerIngenio<T>
    {
        void LogError(string message, params object[] args);
        void LogInformation(string message, params object[] args);
        void LogWarning(string message, params object[] args);
    }
}