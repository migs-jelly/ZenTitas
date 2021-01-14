using System.Collections.Generic;
using Domains.Bootstrap.Code.Core.Behavior;
using Domains.Bootstrap.Code.Logic.Base.Systems;
using Entitas;
using Zenject;

namespace Domains.Bootstrap.SubDomains.Space.Code.Logic.Systems
{
    public class PlayerDirectionSystem : BootstrapReactiveSystem<PlayerEntity>
    {
        private Contexts _contexts;
        
        private ILogger _logger;
        private GameListeners _listeners;
        
        public PlayerDirectionSystem(Contexts contexts) : base(contexts.player)
        {
            _contexts = contexts;
        }

        public override void ResolveDependencies(DiContainer container)
        {
            _logger = container.Resolve<ILogger>();
            _listeners = container.Resolve<GameListeners>();
        }

        protected override ICollector<PlayerEntity> GetTrigger(IContext<PlayerEntity> context)
        {
            return context.CreateCollector(PlayerMatcher.Direction.Added());
        }

        protected override bool Filter(PlayerEntity entity)
        {
            return entity.hasDirection;// && _contexts.game.IsGameRunning();
        }

        protected override void Execute(List<PlayerEntity> entities)
        {
            foreach (var entity in entities)
            {
                _logger.Log($"Direction changed: {entity.direction.HorizontalAxis}");
                _listeners.DirectionListeners.ForEach(l => l.OnDirectionChanged(entity.direction.HorizontalAxis));
            }
        }
    }
}