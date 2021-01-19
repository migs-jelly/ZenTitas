using Entitas;
using Zenject;

namespace Domains.Bootstrap.Code.Logic.Base.Systems
{
    public abstract class ResolvableReactiveSystem<TEntity> : ReactiveSystem<TEntity>, IResolvableSystem where TEntity : class, IEntity
    {
        protected ResolvableReactiveSystem(IContext<TEntity> context) : base(context)
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