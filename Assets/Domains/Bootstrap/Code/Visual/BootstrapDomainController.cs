using Domains.Bootstrap.Code.Visual.Interfaces;
using Entitas;
using UnityEngine;
using Zenject;

namespace Domains.Bootstrap.Code.Visual
{
    public class BootstrapDomainController : MonoBehaviour
    {
        [Inject] private IDomainService _domainService;
        [Inject] private DiContainer _container;

        public async void Init()
        {
            await _domainService.LoadDomain("MainMenu");
        }
        
        public TFeature InstallFeature<TFeature>() where TFeature : Feature
        {
            var existing = _container.TryResolve<TFeature>();
            if(existing == null)
            {
                _container.Bind<TFeature>().AsSingle().NonLazy();
            }
            
            return existing ?? _container.TryResolve<TFeature>();
        }
        public TSystem InstallSystem<TSystem>() where TSystem : class, ISystem
        {
            var existing = _container.TryResolve<TSystem>();
            
            if (existing != null)
            {
                return existing;
            }
            
            _container.Bind<TSystem>().AsSingle().NonLazy();
            return _container.Resolve<TSystem>();

        }
    }
}