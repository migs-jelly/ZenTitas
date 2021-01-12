namespace Domains.Global.SubDomains.Game.Code.Core.Components
{
    public interface IPlayerInput
    {
        float HorizontalAxis { get; }
        bool IsAccelerating { get; }
        bool IsPausePressed { get; }
    }
}