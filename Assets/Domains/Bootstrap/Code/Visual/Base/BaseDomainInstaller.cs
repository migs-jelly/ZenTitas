using System;
using System.Collections.Generic;
using Domains.Bootstrap.Code.Core.Base;
using Domains.Bootstrap.Code.Core.Behavior;
using Domains.Bootstrap.Code.Logic.Base;
using Domains.Bootstrap.Code.Logic.Base.Systems;
using Zenject;

namespace Domains.Bootstrap.Code.Visual.Base
{
    public abstract class BaseDomainInstaller<TModule, TFeature> : MonoInstaller 
        where TModule : IBootstrapModule
        where TFeature : BootstrapFeature
    {
        [Inject] private BootstrapDomainController _bootstrapDomainController;

        private readonly List<IBootstrapResolvableSystem> _systems = new List<IBootstrapResolvableSystem>(20);
        private readonly List<IDisposable> _disposables = new List<IDisposable>(20);
        private TFeature _feature;
        
        public sealed override void InstallBindings()
        {
            Container.Bind<TModule>().AsSingle().NonLazy();
            Install();

            foreach (var system in _systems)
            {
                system.ResolveDependencies(Container);
                system.Enable();
            }

            InstallFeature();

            var module = Container.Resolve<TModule>();
            module.ResolveDependencies(Container);
        }

        protected abstract void Install();

        protected void InstallService<TServiceInterface, TService>() 
            where TServiceInterface : IBootstrapService
            where TService : TServiceInterface
        {
            Container.Bind<TServiceInterface>().To<TService>().AsSingle().NonLazy();
            var service = Container.Resolve<TServiceInterface>();
            _disposables.Add(service);
        }

        protected void InstallService<TServiceInterface, TService>(TService service) 
            where TServiceInterface : IBootstrapService
            where TService : TServiceInterface
        {
            Container.Bind<TService>().To<TService>().FromInstance(service).AsSingle();
            _disposables.Add(service);
        }

        protected void InstallDependency<TDependency>() where TDependency : IDisposable
        {
            Container.Bind<TDependency>().AsSingle().NonLazy();
            _disposables.Add(Container.Resolve<TDependency>());
        }

        protected void InstallDependency<TDependency>(TDependency dependency) where TDependency : IDisposable
        {
            Container.Bind<TDependency>().FromInstance(dependency).AsSingle();
            _disposables.Add(dependency);
        }

        protected void InstallSystem<TSystem>() where TSystem : class, IBootstrapResolvableSystem
        {
            var system = _bootstrapDomainController.InstallSystem<TSystem>();
            _systems.Add(system);
        }

        private void InstallFeature()
        {
            _feature = _bootstrapDomainController.InstallFeature<TFeature>();
            _feature.Setup(Container);
            _feature.Enable();
        }

        private void OnDestroy()
        {
            foreach (var disposable in _disposables)
            {
                disposable.Dispose();
            }

            foreach (var system in _systems)
            {
                system.Disable();
            }
            
            _feature.Disable();
        }
    }
}