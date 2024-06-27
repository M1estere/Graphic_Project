using Player.Input;
using Player.StateMachine;

namespace Player.PlayerStates.Superstates
{
    public class PlayerGroundedState : PlayerState
    {
        protected int _xInput;

        private bool _jumpInput;
        private bool _isGrounded;
        
        public PlayerGroundedState(StateMachine.Player player, PlayerStateMachine stateMachine, PlayerData playerData, string animBoolName)
            : base(player, stateMachine, playerData, animBoolName)
        {
        }

        public override void Enter()
        {
            base.Enter();
            
            _player.JumpState.ResetJumps();
        }

        public override void Exit()
        {
            base.Exit();
        }

        public override void LogicUpdate()
        {
            base.LogicUpdate();

            _xInput = _player.InputHandler.NormalizedInputX;
            _jumpInput = _player.InputHandler.JumpInput;

            if (_player.InputHandler.AttackInputs[(int)CombatInputs.primary])
            {
                _stateMachine.ChangeState(_player.PrimaryAttackState);
            } else if (_player.InputHandler.AttackInputs[(int)CombatInputs.secondary])
            {
                _stateMachine.ChangeState(_player.SecondaryAttackState);
            }
            else if (_jumpInput && _player.JumpState.CanJump())
            {
                _player.InputHandler.UseJumpInput();
                _stateMachine.ChangeState(_player.JumpState);
            }
            else if (!_isGrounded)
            {
                _player.InAirState.StartCoyoteTime();
                _stateMachine.ChangeState(_player.InAirState);
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
    }
}