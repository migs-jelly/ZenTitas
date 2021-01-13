using System;
using System.Collections.Generic;
using Domains.Global.Code.Core.Base;
using Domains.Global.Code.Core.Behavior;
using Domains.Global.Code.Logic.Base;
using Entitas;
using Zenject;

namespace Domains.Global.Code.Visual.Base
{
    public abstract class BaseDomainInstaller<TModule, TFeature> : MonoInstaller 
        where TModule : IGameModule
        where TFeature : BaseFeature
    {
        [Inject] private GlobalDomainController _globalDomainController;

        private readonly List<IJellySystem> _systemsToActivate = new List<IJellySystem>();
        
        public sealed override void InstallBindings()
        {
            Container.Bind<TModule>().AsSingle().NonLazy();
            Install();

            foreach (var system in _systemsToActivate)
            {
                system.ResolveDependencies(Container);
            }
            
            _systemsToActivate.Clear();

            InstallFeature();

            var module = Container.Resolve<TModule>();
            module.ResolveDependencies(Container);
        }

        protected abstract void Install();

        protected void InstallService<TServiceInterface, TService>() 
            where TServiceInterface : IJellyService
            where TService : TServiceInterface
        {
            Container.Bind<TServiceInterface>().To<TService>().AsSingle().NonLazy();
        }

        protected void InstallService<TServiceInterface, TService>(TService service) 
            where TServiceInterface : IJellyService
            where TService : TServiceInterface
        {
            Container.Bind<TService>().To<TService>().FromInstance(service).AsSingle();
        }

        protected void InstallDependency<TDependency>() where TDependency : IDisposable
        {
            Container.Bind<TDependency>().AsSingle().NonLazy();
        }

        protected void InstallDependency<TDependency>(TDependency dependency) where TDependency : IDisposable
        {
            Container.Bind<TDependency>().FromInstance(dependency).AsSingle();
        }

        protected void InstallSystem<TSystem>() where TSystem : class, IJellySystem
        {
            var system = _globalDomainController.InstallSystem<TSystem>();
            _systemsToActivate.Add(system);
        }

        private void InstallFeature()
        {
            var feature = _globalDomainController.InstallFeature<TFeature>();
            feature.Setup(Container);
        }
    }
}