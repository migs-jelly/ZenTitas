using Domains.Bootstrap.Code.Core.Behavior;
using Domains.Bootstrap.Code.Logic;
using Domains.Bootstrap.Code.Visual.Services;
using Zenject;

namespace Domains.Bootstrap.Code.Visual
{
    public class BootstrapModule : IBaseModule
    {
        private IDomainService _domainService;
        private BootstrapFeature _feature;

        public void ResolveDependencies(DiContainer container)
        {
            _feature = container.Resolve<BootstrapFeature>();
            _domainService = container.Resolve<IDomainService>();
        }

        public void Init()
        {
            _feature.Initialize();
        }

        public void Execute()
        {
            _feature.Execute();
        }

        public void Destroy()
        {
            _feature.TearDown();
        }
        
        public void Dispose()
        {
            _feature = null;
            _domainService = null;
        }
    }
}