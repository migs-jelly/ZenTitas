using System.Collections.Generic;
using Domains.Global.Code.Core.Behavior;
using Domains.Global.SubDomains.Space.Code.Logic.Helpers;
using Entitas;
using Zenject;

namespace Domains.Global.SubDomains.Space.Code.Logic.Systems
{
    public class PlayerAccelerationSystem : ReactiveSystem<PlayerEntity>
    {
        private Contexts _contexts;
        
        [Inject] private ILogger _logger;
        
        [Inject]
        public PlayerAccelerationSystem(Contexts contexts) : base(contexts.player)
        {
            _contexts = contexts;
        }

        protected override ICollector<PlayerEntity> GetTrigger(IContext<PlayerEntity> context)
        {
            return context.CreateCollector(PlayerMatcher.Acceleration.Added());
        }

        protected override bool Filter(PlayerEntity entity)
        {
            return entity.hasAcceleration && _contexts.game.IsGameRunning();
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