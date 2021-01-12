using System;
using Domains.Global.Code.Core.Behavior;
using Domains.Global.Code.Visual.Interfaces;
using Domains.Global.SubDomains.Space.Code.Core.Components;
using Domains.Global.SubDomains.Space.Code.Logic;
using Domains.Global.SubDomains.Space.Code.Logic.Listeners;
using Domains.Global.SubDomains.Space.Code.Logic.Systems;
using Domains.Global.SubDomains.Space.Code.Visual.Components;
using EntitasData.Domains.Space;
using Zenject;

namespace Domains.Global.SubDomains.Space.Code.Visual
{
    public class GameModule : IGameModule, IGameStateListener
    {
        [Inject] private DiContainer _container;
        [Inject] private GameFeature _feature;
        [Inject] private Contexts _contexts;
        [Inject] private IDomainService _domainService;
        [Inject] private GameListeners _gameListeners;

        private bool _isExiting;

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
            
        }

        public void Destroy()
        {
            _gameListeners.GameStateListeners.Remove(this);
            _feature.Cleanup();
        }
    }
}