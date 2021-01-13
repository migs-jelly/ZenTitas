using Entitas;
using Zenject;

namespace Domains.Global.Code.Logic.Base
{
    public interface IJellySystem : ISystem
    {
        void ResolveDependencies(DiContainer container);
    }
}