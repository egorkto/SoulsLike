using System;

public interface IInteraction
{
    public event Action Finished;
    public void StartInteraction();
    public void ApplyInteractionState(IInteractionApplyerState state);
}