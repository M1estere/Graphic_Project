using Player.Data;
using UnityEngine;

namespace Player.StateMachine
{
    public class PlayerState
    {
        protected Player _player;
        protected PlayerStateMachine _stateMachine;
        protected PlayerData _playerData;

        protected float _startTime;
        protected bool _isAnimationFinished;
        
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
            _player.Anim.SetBool(_animBoolName, true);
            _startTime = Time.time;
            _isAnimationFinished = false;
        }

        public virtual void Exit()
        {
            _player.Anim.SetBool(_animBoolName, false);
        }

        public virtual void LogicUpdate() { }

        public virtual void PhysicsUpdate()
        {
            DoChecks();
        }

        public virtual void DoChecks() { }

        public virtual void AnimationTrigger() { }

        public virtual void AnimationFinishTrigger() => _isAnimationFinished = true;
    }
}