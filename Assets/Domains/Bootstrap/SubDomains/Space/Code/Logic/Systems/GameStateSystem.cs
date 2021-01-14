using System.Collections.Generic;
using Domains.Bootstrap.Code.Core.Behavior;
using Domains.Bootstrap.Code.Logic.Base.Systems;
using Entitas;
using Zenject;

namespace Domains.Bootstrap.SubDomains.Space.Code.Logic.Systems
{
    public class GameStateSystem : BootstrapResolvableReactiveSystem<GameEntity>
    {
        private Contexts _contexts;
        
        private ILogger _logger;
        private GameListeners _listeners;
        
        public GameStateSystem(Contexts contexts) : base(contexts.game)
        {
            _contexts = contexts;
        }
        
        public override void ResolveDependencies(DiContainer container)
        {
            _logger = container.Resolve<ILogger>();
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

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        {
            return context.CreateCollector(GameMatcher.GameState);
        }

        protected override bool Filter(GameEntity entity)
        {
            return entity.hasGameState;
        }

        protected override void Execute(List<GameEntity> entities)
        {
            foreach (var entity in entities)
            {
                var isRunning = entity.gameState.IsRunning;
                _logger.Log($"Game State changed: {isRunning}");
                _listeners.GameStateListeners.ForEach(l => l.OnGameStateChanged(entity.gameState));
            }
        }
    }
}