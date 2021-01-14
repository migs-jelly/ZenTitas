using ZenTitas.Data.EntitasData.Domains.Space;

namespace Domains.Bootstrap.SubDomains.Space.Code.Logic.Listeners
{
    public interface IGameStateListener
    {
        void OnGameStateChanged(GameState state);
    }
}