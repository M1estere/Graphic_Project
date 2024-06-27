using Player.PlayerStates.Superstates;
using Player.StateMachine;

namespace Player.PlayerStates.Substates
{
    public class PlayerMoveState : PlayerGroundedState
    {
        public PlayerMoveState(StateMachine.Player player, PlayerStateMachine stateMachine, PlayerData playerData, string animBoolName) 
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

            _player.CheckIfShouldFlip(_xInput);
            
            _player.SetVelocityX(_playerData.MovementVelocity * _xInput);
            
            if (_xInput == 0)
            {
                _stateMachine.ChangeState(_player.IdleState);
            }
        }

        public override void PhysicsUpdate()
        {
            base.PhysicsUpdate();
        }

        public override void DoChecks()
        {
            base.DoChecks();
        }
    }
}