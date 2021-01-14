using System;
using Zenject;

namespace Domains.Bootstrap.Code.Core.Behavior
{
    public interface IBootstrapModule : IDisposable
    {
        void ResolveDependencies(DiContainer container);
        void Init();
        void Execute();
        void Destroy();
    }
}