using System;
using UnityEngine;

public class PlayerMover : MonoBehaviour, IPlayerMover
{
    public event Action Fall;
    public event Action Land;

    public float YSpeed => _yMoving;
    public bool Grounded => _controller.isGrounded;

    [SerializeField] private CharacterController _controller;
    [SerializeField] private float _gravityForce;

    private Vector3 _planeMoving;
    private float _yMoving = 0;
    private float _currentSpeed = 0;
    private bool _isFalling;

    private const float _minFallYSpeed = 3f;

    public void SetPlaneSpeed(float speed)
    {
        _currentSpeed = speed;
    }

    public void SetVerticalSpeed(float speed)
    {
        _yMoving = speed;
    }

    private void Update()
    {
        _planeMoving = transform.forward * _currentSpeed;
        _controller.Move(new Vector3(_planeMoving.x, _yMoving, _planeMoving.z) * Time.deltaTime);
        if (!_controller.isGrounded)
        {
            _yMoving -= _gravityForce * Time.deltaTime;
            if(_yMoving < -_minFallYSpeed && !_isFalling)
            {
                _isFalling = true;
                Fall?.Invoke();
            }      
        }
        else if(_isFalling)
        {
            _isFalling = false;
            Land?.Invoke();
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawLine(new Vector3(transform.position.x, transform.position.y + 1f, transform.position.z), new Vector3(transform.forward.x * 15, transform.position.y + 1f, transform.forward.z * 15));
    }
}