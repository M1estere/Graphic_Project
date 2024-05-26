using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    [Header("For Jumping")]
    [SerializeField] private Transform _groundCheck;
    [SerializeField] private LayerMask _groundLayer;
    [Space(5)]

    [Header("Traversal Params Setup")]
    [SerializeField, Range(1, 25)] private float _speed;
    [SerializeField, Range(0, 100)] private float _jumpingPower;

    private Rigidbody2D _rigidbody;

    private float _horizontal;
    private bool _isFacingRight = true;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        _horizontal = Input.GetAxisRaw("Horizontal");

        if (Input.GetButtonDown("Jump") && Grounded())
        {
            Jump();
        }

        if (Input.GetButtonUp("Jump") && _rigidbody.velocity.y > 0)
        {
            _rigidbody.velocity = new Vector2(_rigidbody.velocity.x, _rigidbody.velocity.y * .5f);
        }

        Flip();
    }

    private void FixedUpdate()
    {
        _rigidbody.velocity = new Vector2(_horizontal * _speed, _rigidbody.velocity.y);
    }

    public bool Grounded() => Physics2D.OverlapCircle(_groundCheck.position, .2f, _groundLayer);

    public void Jump()
    {
        GetComponent<PlayerAnimatorController>().Jump();
        _rigidbody.velocity = new Vector2(_rigidbody.velocity.x, _jumpingPower);
    }

    public void Jump(float force)
    {
        GetComponent<PlayerAnimatorController>().Jump();
        _rigidbody.velocity = new Vector2(_rigidbody.velocity.x, force);
    }

    private void Flip()
    {
        if (_isFacingRight && _horizontal < 0 || !_isFacingRight && _horizontal > 0)
        {
            _isFacingRight = !_isFacingRight;

            Vector3 localScale = transform.localScale;
            localScale.x *= -1;
            transform.localScale = localScale;
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        GetComponent<PlayerAnimatorController>().StopJumping();
    }
}
