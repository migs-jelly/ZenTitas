using Domains.Bootstrap.Code.Logic.Base;
using Domains.Bootstrap.Code.Logic.Base.Systems;
using Domains.Bootstrap.SubDomains.Space.Code.Logic.Systems;
using Zenject;

namespace Domains.Bootstrap.SubDomains.Space.Code.Logic
{
    public class SpaceFeature : BootstrapFeature
    {
        public override void Setup(DiContainer container)
        {
            Add<InputSystem>(container);
            Add<PlayerAccelerationSystem>(container);
            Add<PlayerDirectionSystem>(container);
            Add<GameStateSystem>(container);
            Add<ResolvableTeardownSystem>(container);
        }

        public override void Disable()
        {
            //TODO: Disable Feature
        }

        public override void Enable()
        {
            //TODO: Enable Feature
        }
    }
}