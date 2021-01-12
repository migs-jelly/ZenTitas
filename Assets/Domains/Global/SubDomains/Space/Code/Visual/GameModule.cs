using Domains.Global.Code.Core.Behavior;
using Domains.Global.SubDomains.Space.Code.Core.Components;
using Domains.Global.SubDomains.Space.Code.Logic;
using Domains.Global.SubDomains.Space.Code.Logic.Systems;
using Domains.Global.SubDomains.Space.Code.Visual.Components;
using Zenject;

namespace Domains.Global.SubDomains.Space.Code.Visual
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