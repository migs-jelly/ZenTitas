using Domains.Bootstrap.Code.Core.Behavior;
using Domains.Bootstrap.Code.Visual.Services;
using Domains.Bootstrap.SubDomains.Space.Code.Logic;
using Domains.Bootstrap.SubDomains.Space.Code.Logic.Listeners;
using Zenject;
using ZenTitas.Data.EntitasData.Domains.Space;

namespace Domains.Bootstrap.SubDomains.Space.Code.Visual
{
    public class SpaceModule : IBaseModule, IGameStateListener
    {
        private SpaceFeature _feature;
        private Contexts _contexts;
        private IDomainService _domainService;
        private GameListeners _gameListeners;

        private bool _isExiting;

        public void ResolveDependencies(DiContainer container)
        {
            _feature = container.Resolve<SpaceFeature>();
            _contexts = container.Resolve<Contexts>();
            _domainService = container.Resolve<IDomainService>();
            _gameListeners = container.Resolve<GameListeners>();
        }

        public void Init()
        {
            var entity = _contexts.game.CreateEntity();
            entity.ReplaceGameState(true);
            
            _gameListeners.GameStateListeners.Add(this);
            
            _feature.Initialize();
        }
        
        public async void OnGameStateChanged(GameState state)
        {
            if (_isExiting)
            {
                return;
            }
            
            if (!state.IsRunning)
            {
                _isExiting = true;
                await _domainService.LoadDomain("MainMenu");
            }
        }

        public void Execute()
        {
            _feature.Execute();
        }

        public void Destroy()
        {
            _feature.TearDown();
        }

        public void Dispose()
        {
            _gameListeners?.GameStateListeners?.Remove(this);
        }
    }
}