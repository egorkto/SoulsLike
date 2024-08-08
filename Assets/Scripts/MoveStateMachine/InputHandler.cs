using UnityEngine;
using UnityEngine.InputSystem;

public class InputHandler : MonoBehaviour
{
    [SerializeField] private PlayerStats _stats;
    [SerializeField] private PlayerMover _mover;
    [SerializeField] private PlayerRotator _rotator;
    [SerializeField] private StateAnimator _stateAnimator;
    [SerializeField] private ComboAttackTimer _attacker;
    [SerializeField] private PlayerInteractionsHandler _interractionsHandler;

    private PlayerStateMachine _stateMachine;

    public void OnMove(InputValue value)
    {
        if (value.Get<Vector2>() == Vector2.zero)
            _stateMachine.OnStop();
        else
            _stateMachine.OnMove();
    }

    public void OnRun(InputValue value)
    {
        if (value.isPressed)
            _stateMachine.OnStartRun();
        else
            _stateMachine.OnStopRun();
    }

    public void OnCrouch()
    {
        _stateMachine.OnCrouch();
    }

    public void OnJump()
    {
        _stateMachine.OnJump();
    }

    public void OnDash()
    {
        _stateMachine.OnDash();
    }

    public void OnAttack()
    {
        _stateMachine.OnAttack();
    }

    public void OnInterract()
    {
        _stateMachine.OnInterract();
    }

    private void Start()
    {
        _stateMachine = new PlayerStateMachine(_stats, _mover, _rotator, _attacker, _interractionsHandler, _stateAnimator);
    }

    private void Update()
    {
        Debug.Log(_stateMachine.CurrentState.AnimatorTrigger);
    }
}
