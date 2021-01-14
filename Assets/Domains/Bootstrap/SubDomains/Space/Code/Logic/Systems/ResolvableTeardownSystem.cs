using Domains.Bootstrap.Code.Logic.Base.Systems;
using Zenject;

namespace Domains.Bootstrap.SubDomains.Space.Code.Logic.Systems
{
    public class ResolvableTeardownSystem : IBootstrapResolvableTeardownSystem
    {
        private Contexts _contexts;
        private DiContainer _container;

        public void ResolveDependencies(DiContainer container)
        {
            _contexts = container.Resolve<Contexts>();
            _container = container;
        }

        public void Disable()
        {
            //TODO: Disable the system
            //Consider to provide basic implementation in the base class
        }

        public void Enable()
        {
            //TODO: Enable the system
            //Consider to provide basic implementation in the base class
        }
        
        public void TearDown()
        {
            _contexts.game.GetGroup(GameMatcher.GameState).GetSingleEntity()?.Destroy();
            
            var playerEntities = _contexts.player.GetEntities();
            foreach (var playerEntity in playerEntities)
            {
                playerEntity.Destroy();
            }
        }
    }
}