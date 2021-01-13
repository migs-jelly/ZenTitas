using Entitas;
using Zenject;

namespace Domains.Global.Code.Logic.Base
{
    public abstract class BaseFeature : Feature
    {
        public abstract void Setup(DiContainer container);

        protected void Add<TSystem>(DiContainer container) where TSystem : ISystem
        {
            Add(container.Resolve<TSystem>());
        }
    }
}