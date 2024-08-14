using UnityEngine;

public abstract class InterruptedState : PlayerState
{
    public InterruptedState(IPlayerStateMachine stateMachine) : base(stateMachine) { }

    public override void Fall()
    {
        StateMachine.SwitchState<FallState>();
    }
}
