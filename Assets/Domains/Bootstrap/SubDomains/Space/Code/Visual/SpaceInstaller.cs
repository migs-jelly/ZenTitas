using Domains.Bootstrap.Code.Visual.Base;
using Domains.Bootstrap.SubDomains.Space.Code.Core.Services;
using Domains.Bootstrap.SubDomains.Space.Code.Logic;
using Domains.Bootstrap.SubDomains.Space.Code.Logic.Systems;
using Domains.Bootstrap.SubDomains.Space.Code.Visual.Components;

namespace Domains.Bootstrap.SubDomains.Space.Code.Visual
{
    public class SpaceInstaller : BaseDomainInstaller<SpaceModule, SpaceFeature>
    {
        protected override void Install()
        {
            //General
            InstallService<IPlayerInputService, PlayerInputService>();
            
            //Listeners
            InstallDependency<GameListeners>();
            
            //Systems
            InstallSystem<InputSystem>();
            InstallSystem<PlayerAccelerationSystem>();
            InstallSystem<PlayerDirectionSystem>();
            InstallSystem<GameStateSystem>();
            InstallSystem<TeardownSystem>();
        }
    }
}