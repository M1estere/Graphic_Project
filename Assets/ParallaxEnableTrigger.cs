using System.Collections.Generic;
using UnityEngine;

public class ParallaxEnableTrigger : MonoBehaviour
{
    [SerializeField] private ParallaxLayer[] _layersToEnable;

    private List<float> _parallaxSpeeds = new();

    private void Start()
    {
        foreach (var layer in _layersToEnable)
        {
            _parallaxSpeeds.Add(layer.ParallaxFactor);
            layer.ParallaxFactor = 0;
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.TryGetComponent(out PlayerController controller) == false) return;

        for (int i = 0; i < _layersToEnable.Length; i++)
            _layersToEnable[i].ParallaxFactor = _parallaxSpeeds[i];
    }
}
