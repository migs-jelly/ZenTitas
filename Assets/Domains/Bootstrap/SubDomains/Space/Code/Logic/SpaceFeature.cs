using Domains.Bootstrap.Code.Logic.Base;
using Domains.Bootstrap.SubDomains.Space.Code.Logic.Systems;
using Zenject;

namespace Domains.Bootstrap.SubDomains.Space.Code.Logic
{
    public class SpaceFeature : BaseFeature
    {
        public override void Setup(DiContainer container)
        {
            Add<InputSystem>(container);
            Add<PlayerAccelerationSystem>(container);
            Add<PlayerDirectionSystem>(container);
            Add<GameStateSystem>(container);
            Add<TeardownSystem>(container);
        }
    }
}