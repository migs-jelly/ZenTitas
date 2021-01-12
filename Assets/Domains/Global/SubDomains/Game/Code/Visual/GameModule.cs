using System.Collections.Generic;
using Domains.Global.Code.Core.Behavior;
using Domains.Global.SubDomains.Game.Code.Core.Components;
using Domains.Global.SubDomains.Game.Code.Logic;
using Domains.Global.SubDomains.Game.Code.Logic.Game;
using Domains.Global.SubDomains.Game.Code.Logic.Input;
using Domains.Global.SubDomains.Game.Code.Logic.Listeners;
using Domains.Global.SubDomains.Game.Code.Logic.Player;
using Domains.Global.SubDomains.Game.Code.Visual.Components;
using Zenject;

namespace Domains.Global.SubDomains.Game.Code.Visual
{
    public class GameModule : IGameModule
    {
        [Inject] private DiContainer _container;
        
        private GameFeature _feature;
        
        public void InstallBindings()
        { 
            //General
            _container.Bind<Contexts>().FromInstance(Contexts.sharedInstance).NonLazy();
            _container.Bind<IPlayerInput>().To<PlayerInput>().AsSingle().NonLazy();
            
            //Listeners
            _container.Bind<GameListeners>().AsSingle().NonLazy();
            
            //Systems
            _container.Bind<InputSystem>().AsSingle().NonLazy();
            _container.Bind<PlayerAccelerationSystem>().AsSingle().NonLazy();
            _container.Bind<PlayerDirectionSystem>().AsSingle().NonLazy();
            _container.Bind<GameStateSystem>().AsSingle().NonLazy();
            
            //Feature
            _container.Bind<GameFeature>().AsSingle().NonLazy();
            
            //Initialization
            //TODO: Move to separate method
            _feature = _container.Resolve<GameFeature>();
        }

        public void Start()
        {
            _feature.Initialize();
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
            _feature.Cleanup();
        }
    }
}