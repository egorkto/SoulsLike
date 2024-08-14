using UnityEngine.InputSystem;

public class PlayerMoveInput
{
    private PlayerStateMachine _machine;
    private InputActions _input;
    private bool _isMoving;
    private bool _isRunning;

    public PlayerMoveInput(InputActions input, PlayerStateMachine machine) 
    {
        _machine = machine;
        _machine.StateSwitched += OnStateSwitched;
        _input = input;
        _input.Player.Move.performed += OnMove;
        _input.Player.Move.canceled += OnStop;
        _input.Player.Run.performed += OnStartRun;
        _input.Player.Run.canceled += OnStopRun;
        _input.Player.Crouch.performed += OnCrouch;
        _input.Player.Jump.performed += OnJump;
        _input.Player.Dash.performed += OnDash;
        _input.Enable();
    }

    ~PlayerMoveInput()
    {
        _machine.StateSwitched -= OnStateSwitched;
        _input.Player.Move.performed -= OnMove;
        _input.Player.Move.canceled -= OnStop;
        _input.Player.Run.performed -= OnStartRun;
        _input.Player.Run.canceled -= OnStopRun;
        _input.Player.Crouch.performed -= OnCrouch;
        _input.Player.Jump.performed -= OnJump;
        _input.Player.Dash.performed -= OnDash;
        _input.Disable();
    }

    private void OnStateSwitched()
    {
        if(_isMoving)
            _machine.Move();
        if(_isRunning)
            _machine.StartRun();
    }

    private void OnMove(InputAction.CallbackContext context)
    {
        _isMoving = true;
        _machine.Move();
    }

    private void OnStop(InputAction.CallbackContext context)
    {
        _isMoving = false;
        _machine.Stop();
    }

    private void OnStartRun(InputAction.CallbackContext context)
    {
        _isRunning = true;
        _machine.StartRun();
    }

    private void OnStopRun(InputAction.CallbackContext context)
    {
        _isRunning = false;
        _machine.StopRun();
    }

    private void OnCrouch(InputAction.CallbackContext context)
    {
        _machine.Crouch();
    }

    private void OnJump(InputAction.CallbackContext context)
    {
        _machine.Jump();
    }

    private void OnDash(InputAction.CallbackContext context)
    {
        _machine.Dash();
    }
}
