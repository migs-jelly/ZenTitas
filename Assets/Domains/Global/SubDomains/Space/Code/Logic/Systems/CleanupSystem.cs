using Entitas;
using Zenject;

namespace Domains.Global.SubDomains.Space.Code.Logic.Systems
{
    public class CleanupSystem : ICleanupSystem
    {
        [Inject] private Contexts _contexts;
        
        public void Cleanup()
        {
            //TODO: Check why sometimes the entities are not destroyed, but retained
            _contexts.game.GetGroup(GameMatcher.GameState).GetSingleEntity().Destroy();
            
            var playerEntities = _contexts.player.GetEntities();
            foreach (var playerEntity in playerEntities)
            {
                playerEntity.Destroy();
            }
        }
    }
}