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
        where TFeature : BaseFeature
    {
        [Inject] private BootstrapDomainController _bootstrapDomainController;

        private readonly List<IBootstrapSystem> _systemsToActivate = new List<IBootstrapSystem>();
        
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
            where TServiceInterface : IBootstrapService
            where TService : TServiceInterface
        {
            Container.Bind<TServiceInterface>().To<TService>().AsSingle().NonLazy();
        }

        protected void InstallService<TServiceInterface, TService>(TService service) 
            where TServiceInterface : IBootstrapService
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

        protected void InstallSystem<TSystem>() where TSystem : class, IBootstrapSystem
        {
            var system = _bootstrapDomainController.InstallSystem<TSystem>();
            _systemsToActivate.Add(system);
        }

        private void InstallFeature()
        {
            var feature = _bootstrapDomainController.InstallFeature<TFeature>();
            feature.Setup(Container);
        }
    }
}