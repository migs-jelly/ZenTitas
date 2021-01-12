using Entitas;

namespace EntitasData.Domains.Game.Player
{
    [Player]
    public class Death : IComponent
    {
        public bool IsDead;
    }
}