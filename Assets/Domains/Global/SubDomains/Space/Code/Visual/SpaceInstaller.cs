using Domains.Global.Code.Visual;
using Domains.Global.Code.Visual.Base;
using Domains.Global.SubDomains.Space.Code.Core.Services;
using Domains.Global.SubDomains.Space.Code.Logic;
using Domains.Global.SubDomains.Space.Code.Logic.Systems;
using Domains.Global.SubDomains.Space.Code.Visual.Components;
using UnityEngine;
using Zenject;

namespace Domains.Global.SubDomains.Space.Code.Visual
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