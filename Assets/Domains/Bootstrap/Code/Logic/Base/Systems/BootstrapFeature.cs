using Entitas;
using Zenject;

namespace Domains.Bootstrap.Code.Logic.Base.Systems
{
    public abstract class BootstrapFeature : Feature, IBootstrapSystem
    {
        public abstract void Setup(DiContainer container);

        protected void Add<TSystem>(DiContainer container) where TSystem : ISystem
        {
            Add(container.Resolve<TSystem>());
        }

        public abstract void Disable();

        public abstract void Enable();
    }
}