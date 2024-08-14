public class UseSaveStationState : InteractionState
{
    public override string AnimatorStateName => "UseSaveStation";
    
    public UseSaveStationState(IPlayerStateMachine stateMachine, IInteraction interaction) : base(stateMachine, interaction)
    {
    }
}