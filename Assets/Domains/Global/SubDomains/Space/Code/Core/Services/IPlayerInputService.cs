using Domains.Global.Code.Core.Base;

namespace Domains.Global.SubDomains.Space.Code.Core.Services
{
    public interface IPlayerInputService : IJellyService
    {
        float HorizontalAxis { get; }
        bool IsAccelerating { get; }
        bool IsPausePressed { get; }
    }
}