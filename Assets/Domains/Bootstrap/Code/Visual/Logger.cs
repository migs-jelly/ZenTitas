using UnityEngine;
using ILogger = Domains.Bootstrap.Code.Core.Behavior.ILogger;

namespace Domains.Bootstrap.Code.Visual
{
    public class Logger : ILogger
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
    }
}