using Player.Data;
using Player.PlayerStates.Substates;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] protected WeaponData _weaponData;
    
    protected Animator _baseAnimator;
    protected Animator _weaponAnimator;

    protected PlayerAttackState _state;

    protected int _attackCounter;
    
    protected virtual void Awake()
    {
        _baseAnimator = transform.Find("Base").GetComponent<Animator>();
        _weaponAnimator = transform.Find("Weapon").GetComponent<Animator>();
        
        gameObject.SetActive(false);
    }

    public virtual void EnterWeapon()
    {
        gameObject.SetActive(true);

        if (_attackCounter >= _weaponData.AttacksAmount)
        {
            _attackCounter = 0;
        }
        
        _baseAnimator.SetBool("attack", true);
        _weaponAnimator.SetBool("attack", true);
        
        _baseAnimator.SetInteger("attackCounter", _attackCounter);
        _weaponAnimator.SetInteger("attackCounter", _attackCounter);
    }

    public virtual void ExitWeapon()
    {
        _baseAnimator.SetBool("attack", false);
        _weaponAnimator.SetBool("attack", false);

        _attackCounter++;
        
        gameObject.SetActive(false);
    }

    public virtual void AnimationFinishTrigger()
    {
        _state.AnimationFinishTrigger();
    }

    public virtual void AnimationTurnOffFlipTrigger()
    {
        _state.SetFlipCheck(false);
    }

    public virtual void AnimationTurnOnFlipTrigger()
    {
        _state.SetFlipCheck(true);
    }

    public virtual void AnimationActionTrigger()
    {
        
    }
    
    public void InitializeWeapon(PlayerAttackState state)
    {
        _state = state;
    }
}
