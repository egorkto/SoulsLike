using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlayerStateMachine : IPlayerStateMachine
{
    public event Action StateSwitched;

    public IPlayerMover Mover => _playerMover;
    public IPlayerRotator Rotator => _playerRotator;
    public StatesView View => _view;

    private StatesView _view;
    private IPlayerMover _playerMover;
    private IPlayerRotator _playerRotator;
    private PlayerState _currentState;
    private List<PlayerState> _states = new List<PlayerState>();

    public PlayerStateMachine(StatesView view, IPlayerMover playerMover, IPlayerRotator playerRotator)
    {
        _view = view;
        _playerMover = playerMover;
        _playerRotator = playerRotator;
        _playerMover.Fall += Fall;
        _playerMover.Land += Land;
    }

    ~PlayerStateMachine()
    {
        _playerMover.Fall -= Fall;
        _playerMover.Land -= Land;
    }

    public void SetStates(List<PlayerState> states)
    {
        _states = states;
    }

    public void SwitchState<T>() where T : PlayerState
    {
        if (_states.OfType<T>().Count() == 0)
            Debug.LogError("There is no state with type of: " + typeof(T).Name);
        var state = _states.Find(s => s is T);
        // if(_currentState != null)
        //     Debug.Log("Transition: " +  _currentState.AnimatorStateName + " - " + state.AnimatorStateName);
        _currentState = state;
        _currentState.OnEnter();
        _view.View(_currentState);
        StateSwitched?.Invoke();
    }

    public void Move()
    {
        _currentState.StartMove();
    }

    public void Stop()
    {
        _currentState.StopMove();
    }

    public void StartRun()
    {
        _currentState.StartRun();
    }

    public void StopRun()
    {
        _currentState.StopRun();
    }

    public void Crouch()
    {
        _currentState.Crouch();
    }

    public void Jump()
    {
        _currentState.Jump();
    }

    public void Dash()
    {
        _currentState.Dash();
    }

    public void Attack()
    {
        _currentState.Attack();
    }

    public void Interact(IInteraction interaction)
    {
        _currentState.Interact();
    }

    private void Land()
    {
        _currentState.Land();
    }

    private void Fall()
    {
        _currentState.Fall();
    }
}