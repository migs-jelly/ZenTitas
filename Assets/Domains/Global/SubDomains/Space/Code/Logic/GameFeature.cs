using Domains.Global.SubDomains.Space.Code.Logic.Systems;

namespace Domains.Global.SubDomains.Space.Code.Logic
{
    public class GameFeature : Feature
    {
        public GameFeature(InputSystem inputSystem, 
            PlayerAccelerationSystem accelerationSystem,
            PlayerDirectionSystem directionSystem, 
            GameStateSystem gameStateSystem,
            CleanupSystem cleanupSystem)
        {
            Add(inputSystem);
            Add(accelerationSystem);
            Add(directionSystem);
            Add(gameStateSystem);
            Add(cleanupSystem);
        }
    }
}