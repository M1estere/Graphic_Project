using Interfaces;
using UnityEngine;

namespace Enemies
{
    [RequireComponent(typeof(Animator))]
    public class CombatTestDummy : MonoBehaviour, IDamagable
    {
        private Animator _animator;

        private void Awake()
        {
            _animator = GetComponent<Animator>();
        }

        public void Damage(float amount)
        {
            print("Got damage: " + amount);
            _animator.SetTrigger("damage");
        }
    }
}
