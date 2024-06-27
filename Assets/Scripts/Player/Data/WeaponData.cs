using UnityEngine;

namespace Player.Data
{
    [CreateAssetMenu(fileName = "Weapon Data", menuName = "Data/Player Data/Weapon Data")]
    public class WeaponData : ScriptableObject
    {
        [field: Header("Animations")]
        [field: SerializeField] public int AnimationsAmount { get; private set; }
    }
}