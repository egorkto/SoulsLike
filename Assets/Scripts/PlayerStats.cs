using UnityEngine;

[CreateAssetMenu(fileName = "PlayerStats", menuName = "Scriptable Objects/PlayerStats")]
public class PlayerStats : ScriptableObject, IPlayerMoveStats
{
    public float WalkSpeed => _walkSpeed;
    public float RunSpeed => _runSpeed;
    public float CrouchSpeed => _crouchSpeed;
    public float FastCrouchSpeed => _fastCrouchSpeed;
    public float JumpForce => _jumpForce;
    public float RollForce => _rollForce;
    public float JumpBackForce => _jumpBackForce;
    public float FallSpeed => _fallSpeed;

    [SerializeField] private float _walkSpeed;
    [SerializeField] private float _runSpeed;
    [SerializeField] private float _crouchSpeed;
    [SerializeField] private float _fastCrouchSpeed;
    [SerializeField] private float _jumpForce;
    [SerializeField] private float _rollForce;
    [SerializeField] private float _jumpBackForce;
    [SerializeField] private float _fallSpeed;
}
