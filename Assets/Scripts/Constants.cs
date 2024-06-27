using UnityEngine;

public static class Constants
{
    [System.Serializable]
    public struct WeaponAttackDetails
    {
        [field: SerializeField] public string AttackName { get; private set; }
        [field: SerializeField] public float DamageAmount { get; private set; }
    }
    
    /// <summary>
    /// INPUTS
    /// </summary>
    // axis
    public static readonly string HORIZONTAL_INPUT = "Horizontal";
    public static readonly string VERTICAL_INPUT = "Vertical";

    // buttons
    public static readonly string JUMP_INPUT = "Jump";

    /// <summary>
    /// ANIMATIONS
    /// </summary>
    // player states
    public static readonly string PLAYER_RUNNING_STATE_BOOL = "IsRunning";
    public static readonly string PLAYER_GROUNDED_STATE_BOOL = "IsGrounded";
    public static readonly string PLAYER_Y_VELOCITY_STATE_FLOAT = "YVelocity";
}