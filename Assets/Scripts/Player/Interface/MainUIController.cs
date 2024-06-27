using UnityEngine;

public class MainUIController : MonoBehaviour
{
    [SerializeField] private GameObject _book;
    
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
