using Entitas;
using Zenject;

namespace Domains.Global.Code.Logic.Base
{
    public abstract class JellyReactiveSystem<TEntity> : ReactiveSystem<TEntity>, IJellySystem where TEntity : class, IEntity
    {
        protected JellyReactiveSystem(IContext<TEntity> context) : base(context)
        {
        }

        public abstract void ResolveDependencies(DiContainer container);
    }
}