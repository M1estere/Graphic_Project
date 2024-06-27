using System;
using UnityEngine;

public class NPCDialogueStart : MonoBehaviour
{
    [SerializeField] private GameObject _dialogBox;

    private bool _canActivate = false;
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.TryGetComponent(out PlayerController playerController) == false) return;

        _canActivate = true;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.TryGetComponent(out PlayerController playerController) == false) return;
        _canActivate = false;
    }

    private void Update()
    {
        if (!_canActivate) return;

        /*if (Input.GetKeyDown(KeyCode.E))
        {
            _dialogBox.SetActive(true);
        }*/
    }
}
