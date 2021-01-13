using Domains.Global.Code.Visual.Behavior;
using Domains.Global.Code.Visual.Config;
using Domains.Global.Code.Visual.Helpers;
using Domains.Global.Code.Visual.Interfaces;
using UnityEngine;
using Zenject;
using ILogger = Domains.Global.Code.Core.Behavior.ILogger;

namespace Domains.Global.Code.Visual
{
    public class GlobalDomainInstaller : MonoInstaller
    {
        [SerializeField] private GlobalDomainController _domainController;
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
            
            Container.Bind<GlobalDomainController>().FromInstance(_domainController).AsSingle();
            
            
            _domainController.Init();
        }
    }
}