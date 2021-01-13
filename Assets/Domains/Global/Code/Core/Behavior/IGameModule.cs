using System;
using Zenject;

namespace Domains.Global.Code.Core.Behavior
{
    public interface IGameModule : IDisposable
    {
        void ResolveDependencies(DiContainer container);
        void Start();
        void Update();
        void FixedUpdate();
        void LateUpdate();
        void Destroy();
    }
}