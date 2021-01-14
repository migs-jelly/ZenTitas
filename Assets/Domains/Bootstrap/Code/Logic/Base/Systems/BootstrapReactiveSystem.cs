using Entitas;
using Zenject;

namespace Domains.Bootstrap.Code.Logic.Base.Systems
{
    public abstract class BootstrapReactiveSystem<TEntity> : ReactiveSystem<TEntity>, IBootstrapSystem where TEntity : class, IEntity
    {
        protected BootstrapReactiveSystem(IContext<TEntity> context) : base(context)
        {
        }

        public abstract void ResolveDependencies(DiContainer container);
    }
}