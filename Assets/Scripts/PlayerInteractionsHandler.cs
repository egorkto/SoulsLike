using UnityEngine;

public class PlayerInteractionsHandler : MonoBehaviour
{
    public IInteraction CurrentInteraction => _currentInteraction;

    private IInteraction _currentInteraction;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out IInteraction interaction))
        {
            _currentInteraction = interaction;
            Debug.Log("Enter interact trigger");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent(out IInteraction interaction))
        {
            if (interaction == _currentInteraction)
            {
                _currentInteraction = null;
                Debug.Log("Exit interact trigger");
            }
        }
    }
}
