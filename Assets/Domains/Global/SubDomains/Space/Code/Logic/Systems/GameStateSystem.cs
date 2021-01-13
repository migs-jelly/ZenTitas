using System.Collections.Generic;
using Domains.Global.Code.Core.Behavior;
using Domains.Global.Code.Logic.Base;
using Domains.Global.SubDomains.Space.Code.Logic.Listeners;
using Entitas;
using Zenject;

namespace Domains.Global.SubDomains.Space.Code.Logic.Systems
{
    public class GameStateSystem : JellyReactiveSystem<GameEntity>
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