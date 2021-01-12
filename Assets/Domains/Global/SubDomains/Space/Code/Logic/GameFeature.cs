using Domains.Global.SubDomains.Game.Code.Logic.Game;
using Domains.Global.SubDomains.Game.Code.Logic.Input;
using Domains.Global.SubDomains.Game.Code.Logic.Player;
using Zenject;

namespace Domains.Global.SubDomains.Game.Code.Logic
{
    public class GameFeature : Feature
    {
        public GameFeature(InputSystem inputSystem, 
            PlayerAccelerationSystem accelerationSystem,
            PlayerDirectionSystem directionSystem, 
            GameStateSystem gameStateSystem)
        {
            Add(inputSystem);
            Add(accelerationSystem);
            Add(directionSystem);
            Add(gameStateSystem);
        }
    }
}