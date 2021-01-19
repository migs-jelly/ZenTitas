using System.Collections.Generic;
using Domains.Bootstrap.Code.Core.Behavior;
using Domains.Bootstrap.Code.Core.Services;
using Domains.Bootstrap.Code.Logic.Base.Systems;
using Entitas;
using Zenject;

namespace Domains.Bootstrap.SubDomains.Space.Code.Logic.Systems
{
    public class PlayerDirectionSystem : ResolvableReactiveSystem<PlayerEntity>
    {
        private Contexts _contexts;
        
        private ILoggerService _loggerService;
        private GameListeners _listeners;
        
        public PlayerDirectionSystem(Contexts contexts) : base(contexts.player)
        {
            _contexts = contexts;
        }

        public override void ResolveDependencies(DiContainer container)
        {
            _loggerService = container.Resolve<ILoggerService>();
            _listeners = container.Resolve<GameListeners>();
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
            _listeners = null;
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
                _loggerService.Log($"Direction changed: {entity.direction.HorizontalAxis}");
                _listeners.DirectionListeners.ForEach(l => l.OnDirectionChanged(entity.direction.HorizontalAxis));
            }
        }
    }
}