using System;
using Zenject;

namespace Domains.Bootstrap.Code.Core.Behavior
{
    public interface IBaseModule : IDisposable
    {
        void ResolveDependencies(DiContainer container);
        void Init();
        void Execute();
        void Destroy();
    }
}