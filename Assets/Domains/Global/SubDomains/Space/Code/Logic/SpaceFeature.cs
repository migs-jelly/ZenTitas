using Domains.Global.Code.Logic.Base;
using Domains.Global.SubDomains.Space.Code.Logic.Systems;
using Zenject;

namespace Domains.Global.SubDomains.Space.Code.Logic
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