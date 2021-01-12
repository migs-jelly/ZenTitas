using System;
using Domains.Global.SubDomains.Game.Code.Core.Components;
using Domains.Global.SubDomains.Game.Code.Logic.Helpers;
using Entitas;
using Zenject;

namespace Domains.Global.SubDomains.Game.Code.Logic.Input
{
    public class InputSystem : IExecuteSystem
    {
        private const float AXIS_CHANGE_TOLERANCE = 0.01f;
        
        [Inject] private IPlayerInput _playerInput;
        [Inject] private Contexts _contexts;

        private float _previousHorizontalAxis = 0f;
        private bool _previousIsAccelerated = false;
        
        public void Execute()
        {
            //Direction
            if (Math.Abs(_previousHorizontalAxis - _playerInput.HorizontalAxis) > AXIS_CHANGE_TOLERANCE)
            {
                _previousHorizontalAxis = _playerInput.HorizontalAxis;
                var entity = GetOrCreatePlayerEntity(PlayerMatcher.Direction);
                entity.ReplaceDirection(_previousHorizontalAxis);
            }
            
            //Acceleration
            if (_previousIsAccelerated != _playerInput.IsAccelerating)
            {
                _previousIsAccelerated = _playerInput.IsAccelerating;
                var entity = GetOrCreatePlayerEntity(PlayerMatcher.Acceleration);
                entity.ReplaceAcceleration(_previousIsAccelerated);
            }

            //General
            if (_contexts.game.IsGameRunning() && _playerInput.IsPausePressed)
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