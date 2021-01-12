using UnityEngine;

namespace Domains.Global.Code.Visual
{
    public class Logger : global::Domains.Global.Code.Core.Behavior.ILogger
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