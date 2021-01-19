using Domains.Bootstrap.Code.Logic.Base;
using Domains.Bootstrap.Code.Logic.Base.Systems;
using Domains.Bootstrap.SubDomains.Space.Code.Logic.Systems;
using Zenject;

namespace Domains.Bootstrap.SubDomains.Space.Code.Logic
{
    public class SpaceFeature : BaseFeature
    {
        protected override void Init()
        {
            Add<InputSystem>();
            Add<PlayerAccelerationSystem>();
            Add<PlayerDirectionSystem>();
            Add<GameStateSystem>();
            Add<SpaceTeardownSystem>();
        }
    }
}