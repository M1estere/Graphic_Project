using UnityEngine;

public class MainUIController : MonoBehaviour
{
    [SerializeField] private GameObject _book;
    
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (_book.activeSelf) CloseBook();
            else OpenBook();
        }
    }

    public void OpenBook()
    {
        _book.SetActive(true);
        Time.timeScale = 0;
    }

    public void CloseBook()
    {
        _book.SetActive(false);
        Time.timeScale = 1;
    }
}
