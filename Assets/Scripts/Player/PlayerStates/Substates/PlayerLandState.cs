using Player.PlayerStates.Superstates;
using Player.StateMachine;

namespace Player.PlayerStates.Substates
{
    public class PlayerLandState : PlayerGroundedState
    {
        public PlayerLandState(StateMachine.Player player, PlayerStateMachine stateMachine, PlayerData playerData, string animBoolName) 
            : base(player, stateMachine, playerData, animBoolName)
        {
        }

        public override void LogicUpdate()
        {
            base.LogicUpdate();

            if (_xInput != 0)
            {
                _stateMachine.ChangeState(_player.MoveState);
            }
            else if (_isAnimationFinished)
            {
                _stateMachine.ChangeState(_player.IdleState);
            }
        }
    }
}