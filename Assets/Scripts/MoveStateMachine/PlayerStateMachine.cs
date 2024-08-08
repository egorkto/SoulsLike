using System;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateMachine : IMoveStateMachine
{
    public PlayerState CurrentState => _currentState;
    public PlayerMover Mover => _mover;
    public StateAnimator Animator => _animator;
    public IPlayerMoveStats Stats => _stats;
    public bool IsMoving => _isMoving;
    public bool IsRunning => _isRunning;

    private readonly PlayerMover _mover;
    private readonly IPlayerMoveStats _stats;
    private List<PlayerState> _states;
    private PlayerState _currentState;
    private PlayerInteractionsHandler _interractionsHandler;
    private StateAnimator _animator;
    public bool _isMoving;
    public bool _isRunning;

    public PlayerStateMachine(IPlayerMoveStats stats, PlayerMover mover, IPlayerRotator rotator, 
        ComboAttackTimer attacker, PlayerInteractionsHandler interractionsHandler, StateAnimator animator)
    {
        _mover = mover;
        _stats = stats;
        _interractionsHandler = interractionsHandler;
        _animator = animator;
        _states = new List<PlayerState>()
        {
            new IdleState(this),
            new WalkState(this),
            new RunState(this),
            new IdleCrouchState(this),
            new CrouchState(this),
            new FastCrouchState(this),
            new RollState(this, rotator),
            new JumpBackState(this, rotator),
            new JumpState(this),
            new MoveJumpState(this),
            new FallState(this),
            new LandState(this, rotator),
            new ComboAttack1State(this, rotator, attacker),
            new ComboAttack2State(this, rotator, attacker),
            new FinalComboAttackState(this, rotator)
        };
        _currentState = _states.Find(s => s is IdleState);
        _mover.Fall += OnFall;
        _mover.Land += OnLand;
    }

    ~PlayerStateMachine()
    {
        _mover.Fall -= OnFall;
        _mover.Land -= OnLand;
    }

    public void SwitchState<T>() where T : PlayerState
    {
        var state = _states.Find(s => s is T);
        //Debug.Log("Transition: " +  _currentState.AnimatorTrigger + " - " + state.AnimatorTrigger);
        _currentState = state;
        _currentState.Enter();
    }

    public void OnMove()
    {
        _isMoving = true;
        _currentState.StartMove();
    }

    public void OnStop()
    {
        _isMoving = false;
        _currentState.StopMove();
    }

    public void OnStartRun()
    {
        _isRunning = true;
        _currentState.StartRun();
    }

    public void OnStopRun()
    {
        _isRunning = false;
        _currentState.StopRun();
    }

    public void OnCrouch()
    {
        _currentState.Crouch();
    }

    public void OnJump()
    {
        _currentState.Jump();
    }

    public void OnDash()
    {
        _currentState.Dash();
    }

    private void OnLand()
    {
        _currentState.Land();
    }

    private void OnFall()
    {
        _currentState.Fall();
    }

    public void OnAttack()
    {
        _currentState.Attack();
    }

    public void OnInterract()
    {
        //if (_interractionsHandler.CurrentObject != null)
        _currentState.Interact();
    }
}