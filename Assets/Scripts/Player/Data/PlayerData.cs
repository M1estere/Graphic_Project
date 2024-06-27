using UnityEngine;

[CreateAssetMenu(fileName = "Player Data", menuName = "Data/Player Data/Base Data")]
public class PlayerData : ScriptableObject
{
    [field: Header("Move State")]
    [field: SerializeField] public float MovementVelocity { get; private set; } = 10;
    
    [field: Header("Jump State")]
    [field: SerializeField] public float JumpVelocity { get; private set; } = 15;
    [field: SerializeField] public int JumpsAmount { get; private set; } = 2;

    [field: Header("In Air State")]
    [field: SerializeField] public float CoyoteTime { get; private set; } = .2f;
    [field: SerializeField] public float JumpHeightMultiplier { get; private set; } = .5f;
    
    [field: Header("Check Variables")]
    [field: SerializeField] public float GroundCheckRadius { get; private set; } = .3f;
    [field: SerializeField] public LayerMask GroundMask { get; private set; }
}
