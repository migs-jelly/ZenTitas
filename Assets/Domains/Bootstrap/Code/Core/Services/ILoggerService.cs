using Domains.Bootstrap.Code.Core.Base;

namespace Domains.Bootstrap.Code.Core.Services
{
    public interface ILoggerService : IBaseService
    {
        void Log(string message);
        void LogWarning(string message);
        void LogError(string message);
    }
}