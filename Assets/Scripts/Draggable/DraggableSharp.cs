using UnityEngine;

public class DraggableSharp : DraggableObject
{
    /*[SerializeField] private string _maskToStay = "SoftWall";

    private void FixedUpdate()
    {
        if (_isDragging)
        {
            RestartRigidbody();

            _rigidbody.MovePosition(_position);
            RotateAlongVector();
        }
    }

    private void RotateAlongVector()
    {
        Vector2 dir = (transform.position - _playerTransform.position).normalized;
        
        Quaternion rotationVector = Quaternion.LookRotation(dir);
        rotationVector.x = 0;
        rotationVector.y = 0;
        transform.rotation = rotationVector;
    }

    protected override void SendWithImpulse()
    {
        _rigidbody.freezeRotation = true;

        Vector2 pos = transform.position;
        Vector2 dir = (transform.position - _playerTransform.position).normalized;
        Debug.DrawLine(_playerTransform.position, pos + dir * 5, Color.blue, 10);

        _isDragging = false;
        CanBeDragged = false;
        _rigidbody.AddForce(dir * _impulseForce, ForceMode2D.Impulse);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (_isDragging) return;

        string colLayerName = LayerMask.LayerToName(collision.gameObject.layer);
        string mainLayerName = _maskToStay;

        if (colLayerName == mainLayerName)
            StayOnObject();
    }

    private void StayOnObject()
    {
        StopRigidbody();
    }

    private void StopRigidbody()
    {
        _rigidbody.bodyType = RigidbodyType2D.Static;
        _rigidbody.velocity = Vector3.zero;
        _rigidbody.gravityScale = 0;
    }

    private void RestartRigidbody()
    {
        _rigidbody.gravityScale = 1;
        _rigidbody.bodyType = RigidbodyType2D.Dynamic;
    }*/
}
