using UnityEngine;

[CreateAssetMenu(fileName = "PlayerStats", menuName = "Scriptable Objects/PlayerStats")]
public class PlayerStats : ScriptableObject
{
    public float WalkSpeed => _walkSpeed;
    public float RunSpeed => _runSpeed;
    public float CrouchSpeed => _crouchSpeed;
    public float FastCrouchSpeed => _fastCrouchSpeed;
    public float JumpForce => _jumpForce;
    public float DashForce => _dashForce;

    [SerializeField] private float _walkSpeed;
    [SerializeField] private float _runSpeed;
    [SerializeField] private float _jumpForce;
    [SerializeField] private float _dashForce;
    [SerializeField] private float _crouchSpeed;
    [SerializeField] private float _fastCrouchSpeed;
}
