using UnityEngine;

public abstract class MoveState : StateMachineBehaviour, IMoveState
{
    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        PlayerMoveStateMachine.Instance.EnterState(this);
    }

    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        PlayerMoveStateMachine.Instance.ExitState(this);
    }

    public virtual void OnEnterState(PlayerMover mover, PlayerStats stats) { }
    public virtual void OnExitState(PlayerMover mover) { }
}
