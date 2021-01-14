using System;
using Domains.Bootstrap.Code.Logic.Base.Systems;
using Domains.Bootstrap.SubDomains.Space.Code.Core.Services;
using Domains.Bootstrap.SubDomains.Space.Code.Logic.Helpers;
using Entitas;
using Zenject;

namespace Domains.Bootstrap.SubDomains.Space.Code.Logic.Systems
{
    public class InputSystem : IBootstrapExecuteSystem
    {
        private const float AXIS_CHANGE_TOLERANCE = 0.01f;
        
        private IPlayerInputService _playerInputService;
        private Contexts _contexts;

        private float _previousHorizontalAxis = 0f;
        private bool _previousIsAccelerated = false;
        
        public void ResolveDependencies(DiContainer container)
        {
            _playerInputService = container.Resolve<IPlayerInputService>();
            _contexts = container.Resolve<Contexts>();
        }
        
        public void Execute()
        {
            //Direction
            if (Math.Abs(_previousHorizontalAxis - _playerInputService.HorizontalAxis) > AXIS_CHANGE_TOLERANCE)
            {
                _previousHorizontalAxis = _playerInputService.HorizontalAxis;
                var entity = GetOrCreatePlayerEntity(PlayerMatcher.Direction);
                entity.ReplaceDirection(_previousHorizontalAxis);
            }
            
            //Acceleration
            if (_previousIsAccelerated != _playerInputService.IsAccelerating)
            {
                _previousIsAccelerated = _playerInputService.IsAccelerating;
                var entity = GetOrCreatePlayerEntity(PlayerMatcher.Acceleration);
                entity.ReplaceAcceleration(_previousIsAccelerated);
            }

            //General
            if (_contexts.game.IsGameRunning() && _playerInputService.IsPausePressed)
            {
                _contexts.game.PauseGame();
            }
        }

        private PlayerEntity GetOrCreatePlayerEntity(IMatcher<PlayerEntity> matcher)
        {
            var entities = _contexts.player.GetGroup(Matcher<PlayerEntity>.AnyOf(PlayerMatcher.Acceleration, PlayerMatcher.Direction));

            return entities.count == 0 ? _contexts.player.CreateEntity() : entities.GetSingleEntity();
        }
    }
}