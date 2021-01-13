using Entitas;
using Zenject;

namespace Domains.Global.SubDomains.Space.Code.Logic.Systems
{
    public class CleanupSystem : ICleanupSystem
    {
        [Inject] private Contexts _contexts;
        [Inject] private DiContainer _container;
        
        public void Cleanup()
        {
            var feature = _container.Resolve<SpaceFeature>();
            
            feature.DeactivateReactiveSystems();
            
            //TODO: Check why sometimes the entities are not destroyed, but retained
            _contexts.game.GetGroup(GameMatcher.GameState).GetSingleEntity().Destroy();
            
            var playerEntities = _contexts.player.GetEntities();
            foreach (var playerEntity in playerEntities)
            {
                playerEntity.Destroy();
            }
            
        }
    }
}