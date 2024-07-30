using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAnimatorParametersChanger : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private CharacterController _controller;
    [SerializeField] private float _forgetAttackTriggerTime;

    private Coroutine _forgetAttackCoroutine;
    private bool _isCrouching = false;

    public void OnMove(InputValue value)
    {
        _animator.SetBool("Walk", value.Get<Vector2>() != Vector2.zero);
    }

    public void OnRun(InputValue value)
    {
        _animator.SetBool("Run", value.isPressed);
    }

    public void OnJump()
    {
        if(_animator.GetBool("Grounded"))
            _animator.SetTrigger("Jump");
    }

    public void OnDash()
    {
        _animator.SetTrigger("Dash");
    }

    public void OnCrouch()
    {
        _isCrouching = !_isCrouching;
        _animator.SetBool("Crouch", _isCrouching);
    }

    public void OnAttack()
    {
        _animator.SetTrigger("Attack");
        if(_forgetAttackCoroutine != null)
            StopCoroutine(_forgetAttackCoroutine);
        _forgetAttackCoroutine = StartCoroutine(TryForgetAttackTrigger(_forgetAttackTriggerTime));
    }

    private IEnumerator TryForgetAttackTrigger(float time)
    {
        yield return new WaitForSeconds(time);
        _animator.ResetTrigger("Attack");
    }

    private void Update()
    {
        _animator.SetBool("Grounded", _controller.isGrounded);
    }
}
