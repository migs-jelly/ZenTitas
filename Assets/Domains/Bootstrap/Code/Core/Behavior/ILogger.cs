namespace Domains.Bootstrap.Code.Core.Behavior
{
    public interface ILogger
    {
        void Log(string message);
        void LogWarning(string message);
        void LogError(string message);
    }
}