using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerRotator : MonoBehaviour, IPlayerRotator
{
    [SerializeField] private Camera _camera;
    [SerializeField] private Transform _player;
    [SerializeField] private float _rotationSpeed;

    private bool _canRotating = true;
    private Vector3 _orientation;
    private Vector3 _moveInput;
    private Quaternion _lookRotation;

    public void SetRotating(bool value)
    {
        _canRotating = value;
    }

    public void RotateByInput()
    {
        _player.LookAt(GetRotationVector());
    }

    public void OnMove(InputValue value)
    {
        _moveInput = value.Get<Vector2>();
    }

    public Vector3 GetRotationVector()
    {
        _orientation = _camera.transform.right * _moveInput.x + _camera.transform.forward * _moveInput.y;
        return _player.forward + new Vector3(_orientation.x, 0, _orientation.z);
    }

    private void Update()
    {
        if (_canRotating)
        {
            _lookRotation = Quaternion.LookRotation(GetRotationVector());
            _player.rotation = Quaternion.Slerp(_player.rotation, _lookRotation, _rotationSpeed * Time.deltaTime);
        }
    }
}
