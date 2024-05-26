using System.Collections.Generic;
using UnityEngine;

public class ParallaxSwitcher : MonoBehaviour
{
    [SerializeField] private ParallaxLayer[] _enabledLayers;
    [SerializeField] private ParallaxLayer[] _disabledLayers;

    private List<float> _enabledLayersValues;
    private List<float> _disabledLayersValues;
    
    private void Start()
    {
        _enabledLayersValues = new();
        foreach (ParallaxLayer layer in _enabledLayers)
        {
            _enabledLayersValues.Add(layer.ParallaxFactor);
        }
        
        _disabledLayersValues = new();
        foreach (ParallaxLayer layer in _disabledLayers)
        {
            _disabledLayersValues.Add(layer.ParallaxFactor);
            layer.ParallaxFactor = 0;
        }
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.TryGetComponent(out PlayerController playerController) == false) return;
        
        ToggleLayers();
    }

    private void ToggleLayers()
    {
        if (_enabledLayers[0].ParallaxFactor == 0)
        {
            for (var index = 0; index < _enabledLayers.Length; index++)
            {
                var layer = _enabledLayers[index];
                layer.ParallaxFactor = _enabledLayersValues[index];
            }

            foreach (ParallaxLayer layer in _disabledLayers)
            {
                layer.ParallaxFactor = 0;
            }
        }
        else
        {
            for (var index = 0; index < _disabledLayers.Length; index++)
            {
                var layer = _disabledLayers[index];
                layer.ParallaxFactor = _disabledLayersValues[index];
            }

            foreach (ParallaxLayer layer in _enabledLayers)
            {
                layer.ParallaxFactor = 0;
            }
        }
    }
}
