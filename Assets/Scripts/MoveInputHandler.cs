using UnityEngine;
using UnityEngine.InputSystem;

public class MoveInputHandler : MonoBehaviour
{
    public Vector2 MoveInput => _moveInput;

    [SerializeField] private Animator _animator;

    private Vector2 _moveInput;
    private bool _isCrouching = false;

    public void OnMove(InputValue value)
    {
        _moveInput = value.Get<Vector2>();
        _animator.SetBool("Walk", _moveInput != Vector2.zero);
    }

    public void OnRun(InputValue value)
    {
        _animator.SetBool("Run", value.isPressed);
    }

    public void OnJump()
    {
        _animator.SetTrigger("Jump");
    }

    public void OnRoll()
    {
        _animator.SetTrigger("Roll");
    }

    public void OnCrouch()
    {
        _isCrouching = !_isCrouching;
        _animator.SetBool("Crouch", _isCrouching);
    }
}
