using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent (typeof(CharacterController))]
[RequireComponent(typeof(PlayerInput))]
public class PlayerMover : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    [SerializeField] private float _rotationSpeed;
    [SerializeField] private float _fallAcceleration;

    private CharacterController _controller;
    private Vector3 _moveDirection;
    private Vector3 _orientation;
    private Vector2 _moveInput;
    private Quaternion _lookRotation;
    private float _yMoving = 0;
    private float _currentSpeed = 0;
    private bool _canRotate = true;

    public void OnMove(InputValue value)
    {
        _moveInput = value.Get<Vector2>();
    }

    public void SetPlaneSpeed(float speed)
    {
        _currentSpeed = speed;
    }
    
    public void Jump(float force)
    {
        _yMoving = force;
    }

    public void SetRotating(bool value)
    {
        _canRotate = value;
    }

    private void Start()
    {
        _controller = gameObject.GetComponent<CharacterController>();
    }

    private void Update()
    {
        if(_canRotate)
        {
            _orientation = _camera.transform.right * _moveInput.x + _camera.transform.forward * _moveInput.y;
            _controller.transform.LookAt(new Vector3(_orientation.x, 0, _orientation.z) + _controller.transform.position);
            _lookRotation = Quaternion.LookRotation(transform.forward + new Vector3(_orientation.x, 0, _orientation.z));
            _controller.transform.rotation = Quaternion.Slerp(_controller.transform.rotation, _lookRotation, _rotationSpeed * Time.deltaTime);

        }
        if (!_controller.isGrounded)
            _yMoving -= _fallAcceleration * Time.deltaTime;
        _moveDirection = transform.forward * _currentSpeed;
        _controller.Move(new Vector3(_moveDirection.x, _yMoving, _moveDirection.z) * Time.deltaTime);
    }
}