using Domains.Global.Code.Logic.Base;
using Entitas;
using Zenject;

namespace Domains.Global.SubDomains.Space.Code.Logic.Systems
{
    public class TeardownSystem : IJellyTeardownSystem
    {
        private Contexts _contexts;
        private DiContainer _container;

        public void ResolveDependencies(DiContainer container)
        {
            _contexts = container.Resolve<Contexts>();
            _container = container;
        }
        
        public void TearDown()
        {
            //This is resolved at the time of teardown, to prevent
            //circular dependencies at startup
            var feature = _container.Resolve<SpaceFeature>();
            
            feature.DeactivateReactiveSystems();
            
            //TODO: Check why sometimes the entities are not destroyed, but retained
            _contexts.game.GetGroup(GameMatcher.GameState).GetSingleEntity().Destroy();
            
            var playerEntities = _contexts.player.GetEntities();
            foreach (var playerEntity in playerEntities)
            {
                playerEntity.Destroy();
            }
            
            feature.ClearReactiveSystems();
            feature.ActivateReactiveSystems();
        }
    }
}