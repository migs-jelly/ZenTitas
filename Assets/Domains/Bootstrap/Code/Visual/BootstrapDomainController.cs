using Domains.Bootstrap.Code.Visual.Services;
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
    }
}