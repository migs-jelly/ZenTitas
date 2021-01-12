using Domains.Global.Code.Visual;
using UnityEngine;
using Zenject;

namespace Domains.Global.SubDomains.Space.Code.Visual
{
    public class GameController : MonoBehaviour
    {
        private GameModule _module;
        private GlobalDomainController _globalDomainController;
        
        [Inject] private DiContainer _container;

        private void Awake()
        {
            InstallBindings();
            _globalDomainController.AddModule(_module);
        }

        public void InstallBindings()
        {
            _container.Bind<GameModule>().AsSingle().NonLazy();

            _module = _container.Resolve<GameModule>();
            _globalDomainController = _container.Resolve<GlobalDomainController>();
        }
    }
}