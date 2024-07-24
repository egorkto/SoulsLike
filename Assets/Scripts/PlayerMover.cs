using UnityEngine;

public class PlayerMover : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private Camera _camera;
    [SerializeField] private Animator _animator;
    [SerializeField] private MoveInputHandler _inputHandler;
    [SerializeField] private float _rotationSpeed;
    [SerializeField] private float _fallAcceleration;

    private CharacterController _controller;
    private Vector3 _moveDirection;
    private Vector3 _orientation;
    private float _yMoving = 0;
    private float _currentSpeed = 0;
    private bool _canRotate = true;
    private float _speed = 0;

    public void SetSpeed(float speed)
    {
        _currentSpeed = speed;
    }

    public void Jump(float force)
    {
        _yMoving = force;
    }

    public void Dash(float force, DashDirection direction)
    {
        _currentSpeed = direction == DashDirection.Look ? force : -force;
        if(direction == DashDirection.Back)
            _orientation = _controller.transform.forward;
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
            var rotation = Quaternion.LookRotation(_controller.transform.forward + new Vector3(_orientation.x, 0, _orientation.z));
            _controller.transform.rotation = Quaternion.Slerp(_controller.transform.rotation, rotation, _rotationSpeed * Time.deltaTime);
        }
        if (!_controller.isGrounded)
            _yMoving -= _fallAcceleration * Time.deltaTime;
        _moveDirection = new Vector3(_orientation.x * _currentSpeed, 0, _orientation.z * _currentSpeed);
        _controller.Move(new Vector3(_moveDirection.x, _yMoving, _moveDirection.z) * Time.deltaTime);
        _animator.SetBool("Grounded", _controller.isGrounded);
    }
}

public enum DashDirection
{
    Look,
    Back
}