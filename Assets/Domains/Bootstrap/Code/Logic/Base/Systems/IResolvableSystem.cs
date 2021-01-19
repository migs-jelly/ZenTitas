using Entitas;
using Zenject;

namespace Domains.Bootstrap.Code.Logic.Base.Systems
{
    public interface IResolvableSystem : IBaseSystem
    {
        /// <summary>
        /// Resolves the dependencies for this system
        /// </summary>
        /// <param name="container">Local scope container</param>
        void ResolveDependencies(DiContainer container);
    }
}