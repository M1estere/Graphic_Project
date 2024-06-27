using System.Collections.Generic;
using Interfaces;
using Player.Data;
using UnityEngine;

namespace Player.Weapons
{
    public class AggressiveWeapon : Weapon
    {
        protected AggressiveWeaponData _aggressiveWeaponData;
        
        private List<IDamagable> _detectedDamagables = new ();

        protected override void Awake()
        {
            base.Awake();

            if (_weaponData.GetType() == typeof(AggressiveWeaponData))
            {
                _aggressiveWeaponData = (AggressiveWeaponData)_weaponData;
            }
            else
            {
                Debug.LogError("Wrong data for the weapon");
            }
        }

        public override void AnimationActionTrigger()
        {
            base.AnimationActionTrigger();
            
            CheckMeleeAttack();
        }

        private void CheckMeleeAttack()
        {
            Constants.WeaponAttackDetails details = _aggressiveWeaponData.AttackDetails[_attackCounter];
            
            foreach (IDamagable damagable in _detectedDamagables)
            {
                damagable.Damage(details.DamageAmount);
            }
        }
        
        public void AddToDetected(Collider2D collider)
        {
            IDamagable damagable = collider.GetComponent<IDamagable>();

            if (damagable != null)
            {
                _detectedDamagables.Add(damagable);
            }
        }

        public void RemoveFromDetected(Collider2D collider)
        {
            IDamagable damagable = collider.GetComponent<IDamagable>();

            if (damagable != null)
            {
                _detectedDamagables.Remove(damagable);
            }
        }
    }
}