using UnityEngine;

public class Jumper : MonoBehaviour
{
    [SerializeField] private float _impulseForce = 10;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Rigidbody2D rigidbody) == false) return;
        if (collision.gameObject.TryGetComponent(out PlayerController controller) == false) return;

        if (rigidbody.velocity.y < 0) controller.Jump(_impulseForce);
    }
}
