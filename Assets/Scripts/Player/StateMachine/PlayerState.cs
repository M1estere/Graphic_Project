using UnityEngine;

namespace Player.StateMachine
{
    public class PlayerState
    {
        protected Player _player;
        protected PlayerStateMachine _stateMachine;
        protected PlayerData _playerData;

        protected float _startTime;
        
        private string _animBoolName;

        public PlayerState(Player player, PlayerStateMachine stateMachine, PlayerData playerData, string animBoolName)
        {
            _player = player;
            _stateMachine = stateMachine;
            _playerData = playerData;
            _animBoolName = animBoolName;
        }

        public virtual void Enter()
        {
            DoChecks();
            _startTime = Time.time;
        }

        public virtual void Exit()
        {
            
        }

        public virtual void LogicUpdate()
        {
            
        }

        public virtual void PhysicsUpdate()
        {
            DoChecks();
        }

        public virtual void DoChecks()
        {
            
        }
    }
}