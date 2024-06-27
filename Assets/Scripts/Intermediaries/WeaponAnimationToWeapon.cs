using UnityEngine;

namespace Intermediaries
{
    public class WeaponAnimationToWeapon : MonoBehaviour
    {
        private Weapon _weapon;

        private void Start()
        {
            _weapon = GetComponentInParent<Weapon>();
        }

        private void AnimationFinishTrigger()
        {
            _weapon.AnimationFinishTrigger();
        }

        private void AnimationTurnOffFlipTrigger()
        {
            _weapon.AnimationTurnOffFlipTrigger();
        }

        private void AnimationTurnOnFlipTrigger()
        {
            _weapon.AnimationTurnOnFlipTrigger();
        }
    }
}