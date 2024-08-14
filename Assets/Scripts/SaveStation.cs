public class SaveStation : InteractableObject
{
    public override void ApplyInteractionState(IInteractionApplyerState applyer)
    {
        applyer.ApplyInteraction<UseSaveStationState>();
    }
}
