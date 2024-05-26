using System.Collections.Generic;
using UnityEngine;

public class ParallaxBackground : MonoBehaviour
{
    [SerializeField] private Transform _player;
    [SerializeField] private ParallaxCamera _parallaxCamera;
    [SerializeField] private List<ParallaxLayer> _parallaxLayers = new List<ParallaxLayer>();

    [SerializeField] private float _yOffset = .2f;
    
    private void Start()
    {
        if (_parallaxCamera == null)
            _parallaxCamera = Camera.main.GetComponent<ParallaxCamera>();

        if (_parallaxCamera != null)
        {
            _parallaxCamera.onCameraTranslate += Move;
            _parallaxCamera.onCameraTranslateY += MoveY;
        }
    }

    private void LateUpdate()
    {
        transform.position = new Vector3(_player.transform.position.x, _player.transform.position.y + _yOffset, transform.position.z);
    }

    private void Move(float delta)
    {
        foreach (ParallaxLayer layer in _parallaxLayers)
        {
            layer.Move(delta);
        }
    }

    private void MoveY(float delta)
    {
        foreach (ParallaxLayer layer in _parallaxLayers)
        {
            layer.MoveY(delta);
        }
    }
}
