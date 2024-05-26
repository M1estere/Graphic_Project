using System.Collections;
using UnityEngine;

public class LocationTitleText : MonoBehaviour
{
    [SerializeField] private GameObject _content;
    
    private IEnumerator Start()
    {
        yield return new WaitForSecondsRealtime(1);
        _content.SetActive(true);
        yield return new WaitForSecondsRealtime(5);
        _content.SetActive(false);
    }
}
