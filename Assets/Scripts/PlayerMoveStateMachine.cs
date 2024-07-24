using UnityEngine;

public class PlayerMoveStateMachine : MonoBehaviour
{
    public static PlayerMoveStateMachine Instance = null;

    [SerializeField] private PlayerStats _playerStats;
    [SerializeField] private PlayerMover _playerMover;

    public void Stand()
    {
        _playerMover.SetSpeed(0);
    }

    public void Walk()
    {
        _playerMover.SetSpeed(_playerStats.WalkSpeed);
    }

    public void Run()
    {
        _playerMover.SetSpeed(_playerStats.RunSpeed);
    }

    public void Crouch()
    {
        _playerMover.SetSpeed(_playerStats.CrouchSpeed);
    }

    public void FastCrouch()
    {
        _playerMover.SetSpeed(_playerStats.FastCrouchSpeed);
    }

    public void Jump()
    {
        _playerMover.Jump(_playerStats.JumpForce);
    }

    public void StartDash(DashDirection direction)
    {
        _playerMover.Dash(direction == DashDirection.Look ? _playerStats.RollForce : _playerStats.JumpBackForce, direction);
        _playerMover.StopRotating();
    }

    public void StopDash()
    {
        _playerMover.StartRotating();
    }

    private void Start()
    {
        if (Instance == null) 
            Instance = this;
        else
            Destroy(gameObject);
    }
}
