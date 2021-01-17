using Domains.Bootstrap.Code.Visual.Base;
using Domains.Bootstrap.SubDomains.Space.Code.Core.Services;
using Domains.Bootstrap.SubDomains.Space.Code.Logic;
using Domains.Bootstrap.SubDomains.Space.Code.Logic.Systems;
using Domains.Bootstrap.SubDomains.Space.Code.Visual.Services;
using UnityEngine;

namespace Domains.Bootstrap.SubDomains.Space.Code.Visual
{
    public class SpaceInstaller : BaseDomainInstaller<SpaceModule, SpaceFeature>
    {
        [SerializeField] private BehaviourTestService _behaviourTestService;
        
        
        protected override void Install()
        {
            //Services
            InstallService<IPlayerInputService, PlayerInputService>();
            InstallService<IBehaviourTestService, BehaviourTestService>(_behaviourTestService);
            
            //Listeners
            InstallDependency<GameListeners>();
            
            //Systems
            InstallSystem<InputSystem>();
            InstallSystem<PlayerAccelerationSystem>();
            InstallSystem<PlayerDirectionSystem>();
            InstallSystem<GameStateSystem>();
            InstallSystem<SpaceTeardownSystem>();
        }
    }
}