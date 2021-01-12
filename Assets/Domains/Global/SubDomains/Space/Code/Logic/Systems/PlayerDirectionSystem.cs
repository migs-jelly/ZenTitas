using System.Collections.Generic;
using Domains.Global.Code.Core.Behavior;
using Domains.Global.SubDomains.Space.Code.Logic.Helpers;
using Entitas;
using Zenject;

namespace Domains.Global.SubDomains.Space.Code.Logic.Systems
{
    public class PlayerDirectionSystem : ReactiveSystem<PlayerEntity>
    {
        private Contexts _contexts;
        
        [Inject] private ILogger _logger;
        [Inject] private GameListeners _listeners;
        
        [Inject]
        public PlayerDirectionSystem(Contexts contexts) : base(contexts.player)
        {
            _contexts = contexts;
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