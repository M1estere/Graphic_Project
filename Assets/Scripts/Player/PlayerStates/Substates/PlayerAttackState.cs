using Player.Data;
using Player.PlayerStates.Superstates;
using Player.StateMachine;

namespace Player.PlayerStates.Substates
{
    public class PlayerAttackState : PlayerAbilityState
    {
        private Weapon _weapon;

        private int _xInput;
        private bool _shouldCheckFlip;
        
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

        public override void LogicUpdate()
        {
            base.LogicUpdate();

            _xInput = _player.InputHandler.NormalizedInputX;

            if (_shouldCheckFlip)
            {
                _player.CheckIfShouldFlip(_xInput);
            }
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

        public void SetFlipCheck(bool value)
        {
            _shouldCheckFlip = value;
        }
    }
}