using UnityEngine;

namespace Player.Data
{
    [CreateAssetMenu(fileName = "Aggressive Weapon Data", menuName = "Data/Player Data/Aggressive Weapon Data")]
    public class AggressiveWeaponData : WeaponData
    {
        [SerializeField] private Constants.WeaponAttackDetails[] _attackDetails;

        public Constants.WeaponAttackDetails[] AttackDetails
        {
            get => _attackDetails;
            private set => _attackDetails = value;
        }
        
        private void OnEnable()
        {
            AttacksAmount = _attackDetails.Length;
        }
    }
}