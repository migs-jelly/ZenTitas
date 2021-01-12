using EntitasData.Domains.Game.Game;

namespace Domains.Global.SubDomains.Game.Code.Logic.Listeners
{
    public interface IGameStateListener
    {
        void OnGameStateChanged(GameState state);
    }
}