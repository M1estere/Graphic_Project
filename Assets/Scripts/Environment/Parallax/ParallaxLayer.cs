using UnityEngine;

public class ParallaxLayer : MonoBehaviour
{
    [SerializeField] private float _parallaxFactor;

    public float ParallaxFactor { get => _parallaxFactor; set => _parallaxFactor = value; }

    public void Move(float delta)
    {
        Vector3 newPos = transform.localPosition;
        newPos.x -= delta * _parallaxFactor;

        transform.localPosition = newPos;
    }
}
