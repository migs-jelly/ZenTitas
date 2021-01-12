using EntitasData.Domains.Space;

namespace Domains.Global.SubDomains.Space.Code.Logic.Listeners
{
    public interface IGameStateListener
    {
        void OnGameStateChanged(GameState state);
    }
}