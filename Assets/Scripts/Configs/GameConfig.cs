using UnityEngine;

[CreateAssetMenu(fileName = "Game Config", menuName = "Scr Objects/Game Config", order = 1)]
public class GameConfig : ScriptableObject
{
    [field: SerializeField, Range(2, 15)]
    public float CharacterPower { get; private set; }
}