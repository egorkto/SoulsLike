using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMover : MonoBehaviour
{
    [SerializeField] private CharacterController _controller;
    [SerializeField] private Camera _camera;
    [SerializeField] private PlayerStats _playerStats;
    [SerializeField] private float _fallAcceleration;

    private MoveState _moveState = MoveState.Stand;
    private Vector2 _moveInput;
    private float _yMoving = 0;
    private float _currentSpeed;

    private void Start()
    {
        _currentSpeed = _playerStats.WalkSpeed;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update()
    {
        var moveDirectionRegardingCamera = _camera.transform.right * _moveInput.x + _camera.transform.forward * _moveInput.y;
        var moveDirection = new Vector3(moveDirectionRegardingCamera.x, _yMoving, moveDirectionRegardingCamera.z);
        _controller.Move(moveDirection * _currentSpeed * Time.deltaTime);
        _controller.transform.LookAt(new Vector3(moveDirection.x, 0, moveDirection.z) + _controller.transform.position);
    }

    public void OnMove(InputValue value)
    {
        _moveInput = value.Get<Vector2>();
    }

    public void OnRun(InputValue value)
    {
        _currentSpeed = value.isPressed ? _playerStats.RunSpeed : _playerStats.WalkSpeed;
    }

}

public enum MoveState
{
    Stand,
    Walk,
    Run
}
