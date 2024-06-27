using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    [Header("Run Setup")]
    [SerializeField] private float _movementSpeed = 15;
    [Space(5)]
    
    [Header("Jump Setup")]
    [SerializeField] private Transform _groundCheckTransform;
    [SerializeField] private float _jumpForce = 10;
    [SerializeField] private float _jumpTimerSet = .15f;
    [SerializeField] private float _airDragMultiplier = .9f;
    [SerializeField] private float _groundCheckRadius;
    [SerializeField] private LayerMask _groundLayer;
    [SerializeField] private int _jumpsAmount = 1;
    
    private Rigidbody2D _rigidbody;
    private Animator _animator;

    private bool _isFacingRight = true;
    private bool _isRunning = false;
    private bool _isGrounded = false;
    private bool _canJump = true;
    private int _jumpsLeft;
    private float _jumpTimer;
    private bool _isAttemptingToJump = false;
    
    private float _movementInputDirection;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _animator = GetComponentInChildren<Animator>();

        _jumpsLeft = _jumpsAmount;
    }

    private void Update()
    {
        GetInput();
        CheckMoveDirection();
        UpdateAnimations();
        CheckJumpAbility();
        CheckJump();
    }

    private void FixedUpdate()
    {
        ApplyMovement();
        CheckSurroundings();
    }

    private void CheckJumpAbility()
    {
        if (_isGrounded && _rigidbody.velocity.y <= 0)
        {
            _jumpsLeft = _jumpsAmount;
        }

        _canJump = _jumpsLeft > 0;
    }
    
    private void CheckSurroundings()
    {
        _isGrounded = Physics2D.OverlapCircle(_groundCheckTransform.position, _groundCheckRadius, _groundLayer);
    }
    
    private void CheckMoveDirection()
    {
        if (_isFacingRight && _movementInputDirection < 0)
        {
            Flip();
        } 
        else if (_isFacingRight == false && _movementInputDirection > 0)
        {
            Flip();
        }

        _isRunning = _movementInputDirection != 0;
    }
    
    private void ApplyMovement()
    {
        if (_isGrounded == false)
        {
            _rigidbody.velocity = new Vector2(_movementSpeed * _movementInputDirection * _airDragMultiplier, _rigidbody.velocity.y);
        }
        else if (_isGrounded)
        {
            _rigidbody.velocity = new Vector2(_movementSpeed * _movementInputDirection, _rigidbody.velocity.y);
        }
    }

    private void Jump()
    {
        if (_canJump == false) return;
        
        _rigidbody.velocity = new Vector2(_rigidbody.velocity.x, _jumpForce);
        _jumpsLeft--;
        
        _jumpTimer = 0;
        _isAttemptingToJump = false;
    }

    private void JumpButtonHoldIncrease()
    {
        _rigidbody.velocity = new Vector2(_rigidbody.velocity.x, _rigidbody.velocity.y * .5f);
    }
    
    private void Flip()
    {
        if (_isFacingRight && _movementInputDirection < 0 || !_isFacingRight && _movementInputDirection > 0)
        {
            _isFacingRight = !_isFacingRight;

            transform.Rotate(0, 180, 0);
        }
    }

    private void UpdateAnimations()
    {
        _animator.SetBool(Constants.PLAYER_RUNNING_STATE_BOOL, _isRunning);
        
        _animator.SetBool(Constants.PLAYER_GROUNDED_STATE_BOOL, _isGrounded);
        _animator.SetFloat(Constants.PLAYER_Y_VELOCITY_STATE_FLOAT, Mathf.Clamp(_rigidbody.velocity.y, -1, 1));
    }
    
    private void GetInput()
    {
        _movementInputDirection = Input.GetAxisRaw(Constants.HORIZONTAL_INPUT);

        if (Input.GetButtonDown(Constants.JUMP_INPUT))
        {
            if (_isGrounded)
            {
                Jump();
            }
            else
            {
                _jumpTimer = _jumpTimerSet;
                _isAttemptingToJump = true;
            }
        }
        
        // if (Input.GetButtonUp(Constants.JUMP_INPUT) && _rigidbody.velocity.y > 0) JumpButtonHoldIncrease();
    }

    private void CheckJump()
    {
        if (_jumpTimer > 0)
        {
            if (_isGrounded)
            {
                Jump();
            }
        }
        
        if (_isAttemptingToJump)
        {
            _jumpTimer -= Time.deltaTime;
        }
    }
    
    /// <summary>
    /// DISPLAY GROUND CHECK (DEBUG)
    /// </summary>
    /*private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(_groundCheckTransform.position, _groundCheckRadius);
    }*/
}
