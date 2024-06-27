using Player.Data;
using Player.Input;
using Player.StateMachine;
using UnityEngine;

namespace Player.PlayerStates.Substates
{
    public class PlayerInAirState : PlayerState
    {
        private int _xInput;
        private bool _isGrounded;
        private bool _jumpInput;
        private bool _coyoteTime;
        private bool _isJumping;
        private bool _jumpInputStop;
        
        public PlayerInAirState(StateMachine.Player player, PlayerStateMachine stateMachine, PlayerData playerData, string animBoolName)
            : base(player, stateMachine, playerData, animBoolName)
        {
        }

        public override void Enter()
        {
            base.Enter();
        }

        public override void Exit()
        {
            base.Exit();
        }

        public override void LogicUpdate()
        {
            base.LogicUpdate();
            
            CheckCoyoteTime();

            _xInput = _player.InputHandler.NormalizedInputX;
            _jumpInput = _player.InputHandler.JumpInput;
            _jumpInputStop = _player.InputHandler.JumpInputStop;

            CheckJumpMultiplier();
            
            if (_isGrounded && _player.CurrentVelocity.y < .01f)
            {
                _stateMachine.ChangeState(_player.LandState);
            }
            else if (_jumpInput && _player.JumpState.CanJump())
            {
                _stateMachine.ChangeState(_player.JumpState);
            }
            else
            {
                _player.CheckIfShouldFlip(_xInput);
                _player.SetVelocityX(_playerData.MovementVelocity * _xInput);
                
                _player.Anim.SetFloat("yVelocity", _player.CurrentVelocity.y);
            }
        }

        private void CheckJumpMultiplier()
        {
            if (_isJumping)
            {
                if (_jumpInputStop)
                {
                    _player.SetVelocityY(_player.CurrentVelocity.y * _playerData.JumpHeightMultiplier);
                    _isJumping = false;
                }
                else if (_player.CurrentVelocity.y <= 0)
                {
                    _isJumping = false;
                }
            }
        }
        
        public override void PhysicsUpdate()
        {
            base.PhysicsUpdate();
        }

        public override void DoChecks()
        {
            base.DoChecks();

            _isGrounded = _player.CheckIfGrounded();
        }

        private void CheckCoyoteTime()
        {
            if (_coyoteTime && Time.time > _startTime + _playerData.CoyoteTime)
            {
                _coyoteTime = false;
                _player.JumpState.DecreaseJumps();
            }
        }

        public void StartCoyoteTime() => _coyoteTime = true;

        public void SetIsJumping() => _isJumping = true;
    }
}