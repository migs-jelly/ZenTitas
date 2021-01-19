using System.Collections.Generic;
using Domains.Bootstrap.Code.Core.Behavior;
using Domains.Bootstrap.Code.Core.Services;
using Domains.Bootstrap.Code.Logic.Base.Systems;
using Entitas;
using Zenject;

namespace Domains.Bootstrap.SubDomains.Space.Code.Logic.Systems
{
    public class PlayerAccelerationSystem : ResolvableReactiveSystem<PlayerEntity>
    {
        private Contexts _contexts;
        private ILoggerService _loggerService;
        
        public PlayerAccelerationSystem(Contexts contexts) : base(contexts.player)
        {
            _contexts = contexts;
        }
        
        public override void ResolveDependencies(DiContainer container)
        {
            _loggerService = container.Resolve<ILoggerService>();
        }

        public override void Disable()
        {
            //TODO: Disable the system
            //Consider to provide basic implementation in the base class
        }

        public override void Enable()
        {
            //TODO: Enable the system
            //Consider to provide basic implementation in the base class
        }

        public override void TearDown()
        {
            _loggerService = null;
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
                _loggerService.Log($"Acceleration changed: {entity.acceleration.IsAccelerated}");
            }
        }
    }
}