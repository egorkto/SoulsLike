using UnityEngine;

public class MoveSubStateMachine : StateMachineBehaviour, IMoveState
{
    public override void OnStateMachineEnter(Animator animator, int stateMachinePathHash)
    {
        PlayerMoveStateMachine.Instance.EnterState(this);
    }

    public override void OnStateMachineExit(Animator animator, int stateMachinePathHash)
    {
        PlayerMoveStateMachine.Instance.ExitState(this);
    }

    public void OnEnterState(PlayerMover mover, PlayerStats stats)
    {
        mover.SetRotating(true);
    }

    public void OnExitState(PlayerMover mover)
    {
        mover.SetPlaneSpeed(0);
        mover.SetRotating(false);
    }
}
