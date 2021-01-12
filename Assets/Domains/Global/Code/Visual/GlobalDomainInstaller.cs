using Domains.Global.Code.Visual.Behavior;
using Domains.Global.Code.Visual.Interfaces;
using UnityEngine;
using Zenject;
using ILogger = Domains.Global.Code.Core.Behavior.ILogger;

namespace Domains.Global.Code.Visual
{
    public class GlobalDomainInstaller : MonoInstaller
    {
        [SerializeField] private GlobalDomainController _domainController;
        

        public override void InstallBindings()
        {
            Container.Bind<ILogger>().To<Logger>().AsSingle().NonLazy();
            Container.Bind<IDomainService>().To<DomainService>().AsSingle().NonLazy();
            
            Container.Bind<GlobalDomainController>().FromInstance(_domainController).AsSingle();
        }
        
    }
}