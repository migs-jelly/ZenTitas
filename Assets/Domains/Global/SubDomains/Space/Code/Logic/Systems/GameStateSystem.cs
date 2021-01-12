using System.Collections.Generic;
using Domains.Global.Code.Core.Behavior;
using Domains.Global.SubDomains.Space.Code.Logic.Listeners;
using Entitas;
using Zenject;

namespace Domains.Global.SubDomains.Space.Code.Logic.Systems
{
    public class GameStateSystem : ReactiveSystem<GameEntity>
    {
        private Contexts _contexts;
        
        [Inject] private ILogger _logger;
        [Inject] private GameListeners _listeners;
        
        [Inject]
        public GameStateSystem(Contexts contexts) : base(contexts.game)
        {
            _contexts = contexts;
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