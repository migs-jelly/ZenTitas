using Entitas;
using Zenject;

namespace Domains.Bootstrap.Code.Logic.Base.Systems
{
    public interface IBootstrapSystem : ISystem
    {
        void ResolveDependencies(DiContainer container);
    }
}