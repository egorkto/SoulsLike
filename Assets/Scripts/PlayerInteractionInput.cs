using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInteractionInput : MonoBehaviour
{
    private PlayerInteractionsHandler _interactionsHandler;
    private PlayerStateMachine _machine;
    private InputActions _input;

    public PlayerInteractionInput(InputActions input, PlayerStateMachine machine, PlayerInteractionsHandler interactionsHandler)
    {
        _input = input;
        _machine = machine;
        _interactionsHandler = interactionsHandler;
        _input.Player.Interact.performed += OnInteract;
    }

    ~PlayerInteractionInput()
    {
        _input.Player.Interact.performed -= OnInteract;
    }

    private void OnInteract(InputAction.CallbackContext context)
    {
        if(_interactionsHandler.CurrentInteraction != null)
            _machine.Interact(_interactionsHandler.CurrentInteraction);
    }
}