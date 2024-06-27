using Player.PlayerStates.Superstates;
using Player.StateMachine;

namespace Player.PlayerStates.Substates
{
    public class PlayerJumpState : PlayerAbilityState
    {
        private int _jumpsLeft;
        
        public PlayerJumpState(StateMachine.Player player, PlayerStateMachine stateMachine, PlayerData playerData, string animBoolName) 
            : base(player, stateMachine, playerData, animBoolName)
        {
            _jumpsLeft = _playerData.JumpsAmount;
        }

        public override void Enter()
        {
            base.Enter();
            
            _player.SetVelocityY(_playerData.JumpVelocity);
            _isAbilityDone = true;
            _jumpsLeft--;
            _player.InAirState.SetIsJumping();
        }

        public bool CanJump()
        {
            if (_jumpsLeft > 0)
            {
                return true;
            }

            return false;
        }

        public void ResetJumps() => _jumpsLeft = _playerData.JumpsAmount;

        public void DecreaseJumps() => _jumpsLeft--;
    }
}