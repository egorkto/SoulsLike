using UnityEngine;

public class RollState : UninterruptedState
{
    public override string AnimatorTrigger { get { return "Roll"; } }

    public RollState(IMoveStateMachine stateMachine, IPlayerRotator rotator) : base(stateMachine, rotator) { }

    public override void Complete()
    {
        Debug.Log("Complete roll");
        Rotator.SetRotating(true);
        Exit();
    }

    protected override void OnEnter()
    {
        Mover.SetPlaneSpeed(Stats.RollForce);
        Rotator.SetRotating(false);
    }
}