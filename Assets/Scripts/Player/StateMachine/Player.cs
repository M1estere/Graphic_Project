using Player.Data;
using Player.Input;
using Player.PlayerStates.Substates;
using Player.PlayerStates.Superstates;
using UnityEngine;

namespace Player.StateMachine
{
    [RequireComponent(typeof(Animator), typeof(PlayerInputHandler), typeof(Rigidbody2D))]
    public class Player : MonoBehaviour
    {
        #region State Variables
        public PlayerStateMachine StateMachine { get; private set; }

        public PlayerIdleState IdleState { get; private set; }
        public PlayerMoveState MoveState { get; private set; }
        public PlayerJumpState JumpState { get; private set; }
        public PlayerInAirState InAirState { get; private set; }
        public PlayerGroundedState LandState { get; private set; }
        public PlayerAttackState PrimaryAttackState { get; private set; }
        public PlayerAttackState SecondaryAttackState { get; private set; }
        
        [SerializeField] private PlayerData _playerData;
        #endregion
        
        #region Components
        public Animator Anim { get; private set; }
        public PlayerInputHandler InputHandler { get; private set; }
        public Rigidbody2D PlayerRigidbody { get; private set; }
        public PlayerInventory Inventory { get; private set; }
        #endregion
        
        #region Check Transforms
        [SerializeField] private Transform _groundCheck;
        #endregion
        
        #region Other Variables
        public Vector2 CurrentVelocity { get; private set; }
        public int FacingDirection { get; private set; }

        private Vector2 _workspace;
        #endregion
        
        #region Unity Callbacks
        private void Awake()
        {
            StateMachine = new PlayerStateMachine();
            
            IdleState = new PlayerIdleState(this, StateMachine, _playerData, "idle");
            MoveState = new PlayerMoveState(this, StateMachine, _playerData, "move");
            JumpState = new PlayerJumpState(this, StateMachine, _playerData, "inAir");
            InAirState = new PlayerInAirState(this, StateMachine, _playerData, "inAir");
            LandState = new PlayerLandState(this, StateMachine, _playerData, "land");
            PrimaryAttackState = new PlayerAttackState(this, StateMachine, _playerData, "attack");
            SecondaryAttackState = new PlayerAttackState(this, StateMachine, _playerData, "attack");
        }

        private void Start()
        {
            Anim = GetComponent<Animator>();
            InputHandler = GetComponent<PlayerInputHandler>();
            PlayerRigidbody = GetComponent<Rigidbody2D>();
            Inventory = GetComponent<PlayerInventory>();
            
            FacingDirection = 1;
            
            PrimaryAttackState.SetWeapon(Inventory.Weapons[(int)CombatInputs.primary]);
            // SecondaryAttackState.SetWeapon(Inventory.Weapons[(int)CombatInputs.secondary]);
            
            StateMachine.Initialize(IdleState);
        }

        private void Update()
        {
            CurrentVelocity = PlayerRigidbody.velocity;
            
            StateMachine.CurrentState.LogicUpdate();
        }

        private void FixedUpdate()
        {
            StateMachine.CurrentState.PhysicsUpdate();
        }
        #endregion
        
        #region Set Functions
        public void SetVelocityX(float velocity)
        {
            _workspace.Set(velocity, CurrentVelocity.y);
            
            PlayerRigidbody.velocity = _workspace;
            CurrentVelocity = _workspace;
        }

        public void SetVelocityY(float velocity)
        {
            _workspace.Set(CurrentVelocity.x, velocity);

            PlayerRigidbody.velocity = _workspace;
            CurrentVelocity = _workspace;
        }
        #endregion
        
        #region Check Functions

        public bool CheckIfGrounded()
        {
            return Physics2D.OverlapCircle(_groundCheck.position, _playerData.GroundCheckRadius,
                _playerData.GroundMask);
        }
        
        public void CheckIfShouldFlip(int xInput)
        {
            if (xInput != 0 && xInput != FacingDirection)
            {
                Flip();
            } 
        }
        #endregion
        
        #region Other Functions
        private void AnimationTrigger() => StateMachine.CurrentState.AnimationTrigger();

        private void AnimationFinishTrigger() => StateMachine.CurrentState.AnimationFinishTrigger();
        
        private void Flip()
        {
            FacingDirection *= -1;
            transform.Rotate(0, 180, 0);
        }
        #endregion
    }
}