using UnityEngine;

public class PlayerInputInitializer : MonoBehaviour
{
    [SerializeField] private PlayerInteractionsHandler _interactionHandler;

    private InputActions _input;
    private PlayerMoveInput _moveInput;
    private PlayerInteractionInput _interactionInput;
    private PlayerAttackInput _attackInput;

    public void Initialize(PlayerStateMachine machine)
    {
        _input = new InputActions();
        _moveInput = new PlayerMoveInput(_input, machine);
        _interactionInput = new PlayerInteractionInput(_input, machine, _interactionHandler);
        _attackInput = new PlayerAttackInput(_input, machine);
        _input.Enable();
    }

    private void OnDisable()
    {
        if(_input != null)
            _input.Disable();
        _moveInput = null;
        _interactionInput = null;
        _attackInput = null;
    }
}