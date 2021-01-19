using UnityEngine;

namespace Domains.Bootstrap.Code.Visual
{
    public class LoggerService : Core.Services.ILoggerService
    {
        public void Log(string message)
        {
            Debug.Log(message);
        }

        public void LogWarning(string message)
        {
            Debug.LogWarning(message);
        }

        public void LogError(string message)
        {
            Debug.LogError(message);
        }

        public void Dispose()
        {
        }
    }
}