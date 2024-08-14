public interface IInteractionApplyerState
{
    public void ApplyInteraction<T>() where T : InteractionState;
}