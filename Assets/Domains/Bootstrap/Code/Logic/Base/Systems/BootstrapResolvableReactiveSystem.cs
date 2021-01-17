using Entitas;
using Zenject;

namespace Domains.Bootstrap.Code.Logic.Base.Systems
{
    public abstract class BootstrapResolvableReactiveSystem<TEntity> : ReactiveSystem<TEntity>, IBootstrapResolvableSystem where TEntity : class, IEntity
    {
        protected BootstrapResolvableReactiveSystem(IContext<TEntity> context) : base(context)
        {
        }

        public abstract void ResolveDependencies(DiContainer container);

        public abstract void Disable();

        public abstract void Enable();
        
        /// <summary>
        /// A place to clean all of your references
        /// </summary>
        public abstract void TearDown();
    }
}