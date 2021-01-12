namespace Domains.Global.SubDomains.Space.Code.Logic.Helpers
{
    public static class ContextHelpers
    {
        public static bool IsGameRunning(this GameContext context)
        {
            var entities = context.GetGroup(GameMatcher.GameState);

            if (entities.count == 0)
            {
                return false;
            }

            var entity = entities.GetSingleEntity();

            return entity.hasGameState && entity.gameState.IsRunning;
        }

        public static void StartGame(this GameContext context)
        {
            var entities = context.GetGroup(GameMatcher.GameState);
            var entity = entities.count > 0 ? entities.GetSingleEntity() : context.CreateEntity();
            entity.ReplaceGameState(true);
        }

        public static void PauseGame(this GameContext context)
        {
            var entities = context.GetGroup(GameMatcher.GameState);
            var entity = entities.count > 0 ? entities.GetSingleEntity() : context.CreateEntity();
            entity.ReplaceGameState(false);
        }
    }
}