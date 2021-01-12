using Domains.Global.SubDomains.Game.Code.Data.Game;

namespace Domains.Global.SubDomains.Game.Code.Logic.Listeners
{
    public interface IGameStateListener
    {
        void OnGameStateChanged(GameState state);
    }
}