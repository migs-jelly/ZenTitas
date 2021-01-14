using Domains.Bootstrap.Code.Visual.Config;
using Domains.Bootstrap.Code.Visual.Helpers;
using Domains.Bootstrap.Code.Visual.Interfaces;
using Domains.Bootstrap.Code.Visual.Services;
using UnityEngine;
using Zenject;
using ILogger = Domains.Bootstrap.Code.Core.Behavior.ILogger;

namespace Domains.Bootstrap.Code.Visual
{
    public class BootstrapDomainInstaller : MonoInstaller
    {
        [SerializeField] private BootstrapDomainController _domainController;
        [SerializeField] private DomainsConfigReference _domainsConfigReference;

        public override async void InstallBindings()
        {
            Container.Bind<ILogger>().To<Logger>().AsSingle().NonLazy();
            Container.Bind<IDomainService>().To<DomainService>().AsSingle().NonLazy();
            Container.Bind<Contexts>().FromInstance(Contexts.sharedInstance).NonLazy();

            var domainsConfig = await _domainsConfigReference.LoadAssetAsync().Task;
            Container.Bind<DomainsConfig>().FromInstance(domainsConfig).AsSingle();

            foreach (var domainConfigData in domainsConfig.Domains)
            {
                var domainConfig = await domainConfigData.ConfigReference.LoadAssetAsync().Task;
                Container.Bind<DomainConfig>().WithId(domainConfigData.Name).FromInstance(domainConfig);
            }
            
            Container.Bind<BootstrapDomainController>().FromInstance(_domainController).AsSingle();
            
            
            _domainController.Init();
        }
    }
}