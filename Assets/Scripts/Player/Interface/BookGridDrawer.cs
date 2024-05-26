using UnityEngine;

public class BookGridDrawer : MonoBehaviour
{
    [SerializeField] private Transform _grid;
    [SerializeField] private GameObject _cell;
    [SerializeField] private int _cellCount = 20;
    
    private void Start()
    {
        for (int i = 0; i < _cellCount; i++)
        {
            Instantiate(_cell, _grid);
        }
    }
}
