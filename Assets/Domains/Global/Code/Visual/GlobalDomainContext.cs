using System.Collections.Generic;
using Domains.Global.Code.Core.Behavior;
using Zenject;
using ILogger = Domains.Global.Code.Core.Behavior.ILogger;

namespace Domains.Global.Code.Visual
{
    public class GlobalDomainContext : SceneContext
    {
        private List<IGameModule> _modules = new List<IGameModule>();

        private new void Awake()
        {
            base.Awake();
            InstallBindings();
        }

        private void Update()
        {
            _modules.ForEach(m => m.Update());
        }

        private void FixedUpdate()
        {
            _modules.ForEach(m => m.FixedUpdate());
        }

        private void LateUpdate()
        {
            _modules.ForEach(m => m.LateUpdate());
        }

        private void OnDestroy()
        {
            _modules.ForEach(m => m.Destroy());
        }

        public void AddModule(IGameModule module)
        {
            _modules.Add(module);
            module.InstallBindings();
            module.Start();
        }

        public void InstallBindings()
        {
            Container.Bind<ILogger>().To<Logger>().AsSingle().NonLazy();
            Container.Bind<GlobalDomainContext>().FromInstance(this).AsSingle();
        }
    }
}