using Domains.Global.Code.Visual;
using UnityEngine;
using Zenject;

namespace Domains.Global.SubDomains.Space.Code.Visual
{
    public class GameController : MonoBehaviour
    {
        private GameModule _module;
        private GlobalDomainContext _globalDomainContext;
        
        [Inject] private DiContainer _container;

        private void Awake()
        {
            InstallBindings();
            _globalDomainContext.AddModule(_module);
        }

        public void InstallBindings()
        {
            _container.Bind<GameModule>().AsSingle().NonLazy();

            _module = _container.Resolve<GameModule>();
            _globalDomainContext = _container.Resolve<GlobalDomainContext>();
        }
    }
}