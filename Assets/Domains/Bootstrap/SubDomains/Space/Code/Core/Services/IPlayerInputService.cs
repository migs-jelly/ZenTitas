using Domains.Bootstrap.Code.Core.Base;

namespace Domains.Bootstrap.SubDomains.Space.Code.Core.Services
{
    public interface IPlayerInputService : IBaseService
    {
        float HorizontalAxis { get; }
        bool IsAccelerating { get; }
        bool IsPausePressed { get; }
    }
}