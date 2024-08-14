using UnityEngine;

public abstract class InteractableObject : MonoBehaviour
{
    public abstract void ApplyInteractionState(IInteractionApplyerState applyer);
}
