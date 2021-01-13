using System.Collections.Generic;
using Domains.Global.Code.Core.Behavior;
using Zenject;

namespace Domains.Global.Code.Visual.Base
{
    public abstract class BaseDomainInstaller<TModule> : MonoInstaller where TModule : IGameModule
    {
        public sealed override void InstallBindings()
        {
            Container.Bind<TModule>().AsSingle().NonLazy();
            Install();
        }

        protected abstract void Install();
    }
}