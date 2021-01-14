using Domains.Bootstrap.Code.Visual.Interfaces;
using UnityEngine;
using Zenject;

namespace Domains.Bootstrap.SubDomains.MainMenu.Code.Visual
{
    public class StartGameButton : MonoBehaviour
    {
        [Inject] private IDomainService _domainService;
        
        public async void OnClick()
        {
            await _domainService.LoadDomain("Space");
        }
    }
}