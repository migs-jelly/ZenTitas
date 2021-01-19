using Domains.Bootstrap.Code.Core.Services;
using Domains.Bootstrap.Code.Logic;
using Domains.Bootstrap.Code.Logic.Systems;
using Domains.Bootstrap.Code.Visual.Base;
using Domains.Bootstrap.Code.Visual.Config;
using Domains.Bootstrap.Code.Visual.Helpers;
using Domains.Bootstrap.Code.Visual.Services;
using UnityEngine;
using Zenject;

namespace Domains.Bootstrap.Code.Visual
{
    public class BootstrapDomainInstaller : BaseDomainInstaller<BootstrapModule, BootstrapFeature>
    {

        [SerializeField] private BootstrapDomainController _domainController;
        [SerializeField] private DomainsConfigReference _domainsConfigReference;

        protected override async void Install()
        {
            GetTopContainer().Bind<Contexts>().FromInstance(Contexts.sharedInstance).AsSingle();
            Container.Bind<BootstrapDomainInstaller>().FromInstance(this).AsSingle();
            
            InstallService<ILoggerService, LoggerService>();
            InstallService<IDomainService, DomainService>();
            
            InstallSystem<TimerSystem>();
            
            var domainsConfig = await _domainsConfigReference.LoadAssetAsync().Task;
            Container.Bind<DomainsConfig>().FromInstance(domainsConfig).AsSingle();

            foreach (var domainConfigData in domainsConfig.Domains)
            {
                var domainConfig = await domainConfigData.ConfigReference.LoadAssetAsync().Task;
                Container.Bind<DomainConfig>().WithId(domainConfigData.Name).FromInstance(domainConfig);
            }
            
            _domainController.Init();
        }
    }
}