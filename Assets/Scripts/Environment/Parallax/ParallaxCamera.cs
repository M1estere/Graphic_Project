using UnityEngine;

public class ParallaxCamera : MonoBehaviour
{
    public delegate void ParallaxCameraDelegate(float deltaMovement);
    public ParallaxCameraDelegate onCameraTranslate;
    public ParallaxCameraDelegate onCameraTranslateY;

    private float _oldPosition;
    private float _oldPositionY;

    private void Start()
    {
        _oldPosition = transform.position.x;
        _oldPositionY = transform.position.y;
    }

    private void Update()
    {
        if (transform.position.x != _oldPosition)
        {
            if (onCameraTranslate != null)
            {
                float delta = _oldPosition - transform.position.x;
                onCameraTranslate(delta);
            }

            _oldPosition = transform.position.x;
        }

        if (transform.position.y != _oldPositionY)
        {
            if (onCameraTranslateY != null)
            {
                float delta = _oldPositionY - transform.position.y;
                onCameraTranslateY(delta * 1.5f);
            }

            _oldPositionY = transform.position.y;
        }
    }
}