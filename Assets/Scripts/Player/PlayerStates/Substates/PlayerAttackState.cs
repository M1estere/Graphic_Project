using Player.PlayerStates.Superstates;
using Player.StateMachine;

namespace Player.PlayerStates.Substates
{
    public class PlayerAttackState : PlayerAbilityState
    {
        public PlayerAttackState(StateMachine.Player player, PlayerStateMachine stateMachine, PlayerData playerData, string animBoolName) 
            : base(player, stateMachine, playerData, animBoolName)
        {
        }
    }
}