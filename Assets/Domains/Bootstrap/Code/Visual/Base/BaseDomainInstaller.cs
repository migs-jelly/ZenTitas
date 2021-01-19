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
        where TModule : IBaseModule
        where TFeature : BaseFeature
    {

        private readonly List<IResolvableSystem> _systems = new List<IResolvableSystem>(20);
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

        public void InstallService<TServiceInterface, TService>() 
            where TServiceInterface : IBaseService
            where TService : TServiceInterface
        {
            Container.Bind<TServiceInterface>().To<TService>().AsSingle().NonLazy();
            var service = Container.Resolve<TServiceInterface>();
            _disposables.Add(service);
        }

        public void InstallService<TServiceInterface, TService>(TService service) 
            where TServiceInterface : IBaseService
            where TService : TServiceInterface
        {
            Container.Bind<TService>().To<TService>().FromInstance(service).AsSingle();
            _disposables.Add(service);
        }

        public void InstallDependency<TDependency>() where TDependency : IDisposable
        {
            Container.Bind<TDependency>().AsSingle().NonLazy();
            _disposables.Add(Container.Resolve<TDependency>());
        }

        public void InstallDependency<TDependency>(TDependency dependency) where TDependency : IDisposable
        {
            Container.Bind<TDependency>().FromInstance(dependency).AsSingle();
            _disposables.Add(dependency);
        }
        
        public void InstallFeature()
        {
            var container = GetTopContainer();
            
            var existing = container.TryResolve<TFeature>();
            if(existing == null)
            {
                container.Bind<TFeature>().AsSingle().NonLazy();
            }
            
            _feature = existing ?? container.TryResolve<TFeature>();
            
            _feature.Setup(container);
            _feature.Enable();
        }
        
        public void InstallSystem<TSystem>() where TSystem : class, IResolvableSystem
        {
            var container = GetTopContainer();
            
            var existing = container.TryResolve<TSystem>();
            
            if (existing == null)
            {
                container.Bind<TSystem>().AsSingle().NonLazy();
                existing = Container.Resolve<TSystem>();
            }
            
            _systems.Add(existing);
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

        protected DiContainer GetTopContainer()
        {
            var parent = Container;
            var parents = parent.ParentContainers;
            
            while (parents?.Length > 0)
            {
                parent = parents[0];
                parents = parent.ParentContainers;
            }

            return parent;
        }
    }
}