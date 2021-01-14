using System.Collections.Generic;
using Domains.Bootstrap.Code.Core.Behavior;
using Domains.Bootstrap.Code.Logic.Base.Systems;
using Entitas;
using Zenject;

namespace Domains.Bootstrap.SubDomains.Space.Code.Logic.Systems
{
    public class PlayerAccelerationSystem : BootstrapReactiveSystem<PlayerEntity>
    {
        private Contexts _contexts;
        private ILogger _logger;
        
        public PlayerAccelerationSystem(Contexts contexts) : base(contexts.player)
        {
            _contexts = contexts;
        }
        
        public override void ResolveDependencies(DiContainer container)
        {
            _logger = container.Resolve<ILogger>();
        }

        protected override ICollector<PlayerEntity> GetTrigger(IContext<PlayerEntity> context)
        {
            return context.CreateCollector(PlayerMatcher.Acceleration.Added());
        }

        protected override bool Filter(PlayerEntity entity)
        {
            return entity.hasAcceleration;// && _contexts.game.IsGameRunning();
        }

        protected override void Execute(List<PlayerEntity> entities)
        {
            foreach (var entity in entities)
            {
                _logger.Log($"Acceleration changed: {entity.acceleration.IsAccelerated}");
            }
        }
    }
}