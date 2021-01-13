using System;
using Domains.Global.Code.Core.Behavior;
using Domains.Global.Code.Visual.Interfaces;
using Domains.Global.SubDomains.Space.Code.Logic;
using Domains.Global.SubDomains.Space.Code.Logic.Listeners;
using Domains.Global.SubDomains.Space.Code.Logic.Systems;
using Domains.Global.SubDomains.Space.Code.Visual.Components;
using EntitasData.Domains.Space;
using Zenject;

namespace Domains.Global.SubDomains.Space.Code.Visual
{
    public class SpaceModule : IGameModule, IGameStateListener
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

        public void Start()
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

        public void Update()
        {
            _feature.Execute();
        }

        public void FixedUpdate()
        {
            
        }

        public void LateUpdate()
        {
            _feature.Cleanup();
        }

        public void Destroy()
        {
            _gameListeners.GameStateListeners.Remove(this);
            _feature.TearDown();
        }

        public void Dispose()
        {
            _gameListeners?.Dispose();
        }
    }
}