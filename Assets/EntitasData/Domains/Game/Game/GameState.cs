using Entitas;

namespace EntitasData.Domains.Game.Game
{
    [Game]
    public class GameState : IComponent
    {
        public bool IsRunning;
    }
}