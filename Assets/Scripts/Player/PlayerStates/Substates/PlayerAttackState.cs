using Player.Data;
using Player.PlayerStates.Superstates;
using Player.StateMachine;

namespace Player.PlayerStates.Substates
{
    public class PlayerAttackState : PlayerAbilityState
    {
        private Weapon _weapon;
        
        public PlayerAttackState(StateMachine.Player player, PlayerStateMachine stateMachine, PlayerData playerData, string animBoolName) 
            : base(player, stateMachine, playerData, animBoolName)
        {
        }

        public override void Enter()
        {
            base.Enter();
            
            _weapon.EnterWeapon();
        }

        public override void Exit()
        {
            base.Exit();
            
            _weapon.ExitWeapon();
        }
        
        public void SetWeapon(Weapon weapon)
        {
            _weapon = weapon;
            _weapon.InitializeWeapon(this);
        }
        
        public override void AnimationFinishTrigger()
        {
            base.AnimationFinishTrigger();

            _isAbilityDone = true;
        }
    }
}