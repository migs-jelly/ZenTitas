using Entitas;

namespace EntitasData.Domains.Space
{
    [Game]
    public class GameState : IComponent
    {
        public bool IsRunning;
    }
}