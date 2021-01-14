using Entitas;
using Zenject;

namespace Domains.Bootstrap.Code.Logic.Base.Systems
{
    public abstract class BootstrapFeature : Feature, IBootstrapSystem
    {
        protected DiContainer _container;

        public void Setup(DiContainer container)
        {
            _container = container;
            Init();
        }

        protected abstract void Init();

        protected void Add<TSystem>() where TSystem : ISystem
        {
            Add(_container.Resolve<TSystem>());
        }

        public virtual void Disable()
        {
            DeactivateReactiveSystems();
            ClearReactiveSystems();
        }

        public virtual void Enable()
        {
            ActivateReactiveSystems();
        }
    }
}