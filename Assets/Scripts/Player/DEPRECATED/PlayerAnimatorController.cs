using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(PlayerController))]
public class PlayerAnimatorController : MonoBehaviour
{
    /*[SerializeField] private Animator _animator;
    [SerializeField] private string _speedParameter;
    [Space(5)]

    [SerializeField] private float _walkSpeed;

    private Rigidbody2D _rigidbody;
    private PlayerController _playerController;

    private bool _climbing = false;
    
    public void SetClimbing(bool state)
    {
        if (_climbing == state) return;
        
        print(state);
        _climbing = state;
        _animator.SetBool("Climbing", _climbing);
    }
    
    private void Start()
    {
        _playerController = GetComponent<PlayerController>();
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (Mathf.Abs(_rigidbody.velocity.x) > _walkSpeed)
            _animator.SetFloat(_speedParameter, 1);
        else
            _animator.SetFloat(_speedParameter, 0);

        _animator.SetBool("IsFalling", IsFalling());
    }

    private bool IsFalling()
    {
        if (_rigidbody.velocity.y < 0 && _playerController.Grounded() == false) return true;
        return false;
    }

    public void Jump()
    {
        _animator.SetBool("IsJumping", true);
    }

    public void StopJumping()
    {
        _animator.SetBool("IsJumping", false);
    }*/
}
