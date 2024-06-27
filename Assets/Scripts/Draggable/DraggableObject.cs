using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(Collider2D))]
public abstract class DraggableObject : MonoBehaviour
{
    /*public bool CanBeDragged 
    { 
        get
        {
            return _canBeDragged;
        }
        set
        {
            if (value == _canBeDragged) return;
            
            _canBeDragged = value;
        }
    }
    protected bool _canBeDragged;

    [SerializeField] private GameConfig _gameConfig;

    protected float _objectWeight;
    protected bool _isDragging = false;

    protected Camera _camera;
    protected Transform _playerTransform;

    protected Vector3 _mousePosition;
    protected Vector2 _position;

    protected Rigidbody2D _rigidbody;
    protected Collider2D _collider;

    protected float _moveSpeed = .1f;
    protected float _impulseForce = 15;

    [SerializeField] private float _multiplierMoveSpeed = 10;
    [SerializeField] private float _multiplierImpulseForce = 35;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _collider = GetComponent<Collider2D>();
        _camera = FindObjectOfType<Camera>();

        _position = transform.position;
        _objectWeight = _rigidbody.mass;

        _moveSpeed = (_gameConfig.CharacterPower / _objectWeight) / _multiplierMoveSpeed;
        _impulseForce = (_gameConfig.CharacterPower / _objectWeight) * _multiplierImpulseForce;
    }

    private void Update()
    {
        if (!CanBeDragged && _isDragging) _isDragging = false;  // out of circle radius  
        if (!CanBeDragged) return;    

        if (!_isDragging)
        {
            if (Input.GetKeyDown(KeyCode.Mouse1) && IsTouchingMouse()) 
                _isDragging = true;
        } else
        {
            if (Input.GetKeyDown(KeyCode.Mouse1))
                _isDragging = false;
        }
        
        if (_isDragging)
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
                SendWithImpulse();

            _mousePosition = Input.mousePosition;
            _mousePosition = _camera.ScreenToWorldPoint(_mousePosition);

            _position = Vector2.Lerp(transform.position, _mousePosition, _moveSpeed);
        }
    }

    protected virtual void SendWithImpulse()
    {
        Vector2 pos = transform.position;
        Vector2 dir = (transform.position - _playerTransform.position).normalized;
        Debug.DrawLine(_playerTransform.position, pos + dir * 5, Color.blue, 10);

        _isDragging = false;
        CanBeDragged = false;
        _rigidbody.AddForce(dir * _impulseForce, ForceMode2D.Impulse);
    }

    private void FixedUpdate()
    {
        if (_isDragging)
        {
            _rigidbody.MovePosition(_position);
        }
    }

    private bool IsTouchingMouse()
    {
        Vector2 point = _camera.ScreenToWorldPoint(Input.mousePosition);
        return _collider.OverlapPoint(point);
    }

    public void SetPlayerTransform(Transform player) => _playerTransform = player;*/
}
