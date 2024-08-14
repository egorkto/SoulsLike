using UnityEngine.InputSystem;

public class PlayerAttackInput 
{
    private InputActions _input;
    private PlayerStateMachine _machine;

    public PlayerAttackInput(InputActions input, PlayerStateMachine machine) 
    {
        _input = input;
        _machine = machine;
        _input.Player.Attack.performed += OnAttack;
    }

    ~PlayerAttackInput() 
    {
        _input.Player.Attack.performed -= OnAttack;
    }

    private void OnAttack(InputAction.CallbackContext context)
    {
        _machine.Attack();
    }
}