using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerRotator : MonoBehaviour, IPlayerRotator
{
    [SerializeField] private Camera _camera;
    [SerializeField] private Transform _player;
    [SerializeField] private float _rotationSpeed;

    private bool _canRotating = true;
    private Vector3 _orientation;
    private InputAction _moveInput;
    private Quaternion _lookRotation;
    private InputActions _input;

    public void SetRotating(bool value)
    {
        _canRotating = value;
    }

    public Vector3 GetRotationVector()
    {
        _orientation = _camera.transform.right * _moveInput.ReadValue<Vector2>().x + _camera.transform.forward * _moveInput.ReadValue<Vector2>().y;
        return new Vector3(_orientation.x, 0, _orientation.z);
    }

    private void Awake()
    {
        _input = new InputActions();
    }

    private void OnEnable()
    {
        _moveInput = _input.Player.Move;
        _moveInput.Enable();
    }

    private void OnDisable()
    {
        _moveInput.Disable();
    }

    private void Update()
    {
        if (_canRotating)
        {
            _lookRotation = Quaternion.LookRotation(_player.forward + GetRotationVector());
            _player.rotation = Quaternion.Slerp(_player.rotation, _lookRotation, _rotationSpeed * Time.deltaTime);
        }
    }
}
