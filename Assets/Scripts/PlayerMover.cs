using System.Collections;
using UnityEngine;

public class PlayerMover : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private Camera _camera;
    [SerializeField] private Animator _animator;
    [SerializeField] private MoveInputHandler _inputHandler;
    [SerializeField] private float _speedSlowingInJump;
    [SerializeField] private float _fallAcceleration;

    private CharacterController _controller;
    private Vector3 _moveDirection;
    private Vector3 _orientation;
    private float _yMoving = 0;
    private float _currentSpeed = 0;
    private bool _canRotate = true;

    public void SetSpeed(float speed)
    {
        _currentSpeed = speed;
    }

    public void Jump(float force)
    {
        _yMoving = force;
    }

    public void LookToCamera()
    {
        _orientation = _camera.transform.forward;
        _controller.transform.LookAt(new Vector3(_orientation.x, 0, _orientation.z) + _controller.transform.position);
    }

    public void Dash(float force, DashDirection direction)
    {
        _currentSpeed = direction == DashDirection.Look ? force : -force;
    }
    
    public void StopRotating()
    {
        _canRotate = false;
    }

    public void StartRotating()
    {
        _canRotate = true;
    }

    private void Start()
    {
        _controller = _player.Controller;
    }

    private void Update()
    {
        if(_canRotate)
        {
            _orientation = _camera.transform.right * _inputHandler.MoveInput.x + _camera.transform.forward * _inputHandler.MoveInput.y;
            _controller.transform.LookAt(new Vector3(_orientation.x, 0, _orientation.z) + _controller.transform.position);
        }
        if (_controller.isGrounded)
        {
            _moveDirection = new Vector3(_orientation.x * _currentSpeed, 0, _orientation.z * _currentSpeed);
        }
        else
        {
            _moveDirection = Vector3.Lerp(_moveDirection, Vector3.zero, _speedSlowingInJump * Time.deltaTime);
            _yMoving -= _fallAcceleration * Time.deltaTime;
        }
        _controller.Move(new Vector3(_moveDirection.x, _yMoving, _moveDirection.z) * Time.deltaTime);
        _animator.SetFloat("YSpeed", _controller.velocity.y);
    }
}

public enum DashDirection
{
    Look,
    Back
}