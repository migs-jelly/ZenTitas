using Entitas;

namespace Domains.Global.SubDomains.Game.Code.Data.Game
{
    [Game]
    public class GameState : IComponent
    {
        public bool IsRunning;
    }
}