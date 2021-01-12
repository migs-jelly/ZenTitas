using Domains.Global.SubDomains.Space.Code.Core.Components;
using Domains.Global.SubDomains.Space.Code.Logic;
using Domains.Global.SubDomains.Space.Code.Logic.Systems;
using Domains.Global.SubDomains.Space.Code.Visual.Components;
using Zenject;

namespace Domains.Global.SubDomains.Space.Code.Visual
{
    public class SpaceInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            //General
            Container.Bind<Contexts>().FromInstance(Contexts.sharedInstance).NonLazy();
            Container.Bind<IPlayerInput>().To<PlayerInput>().AsSingle().NonLazy();
            
            //Listeners
            Container.Bind<GameListeners>().AsSingle().NonLazy();
            
            //Systems
            Container.Bind<InputSystem>().AsSingle().NonLazy();
            Container.Bind<PlayerAccelerationSystem>().AsSingle().NonLazy();
            Container.Bind<PlayerDirectionSystem>().AsSingle().NonLazy();
            Container.Bind<GameStateSystem>().AsSingle().NonLazy();
            
            //Feature
            Container.Bind<GameFeature>().AsSingle().NonLazy();
        }
    }
}