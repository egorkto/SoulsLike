using UnityEngine;

public class IdleState : StateMachineBehaviour
{
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        PlayerMoveStateMachine.Instance.Stand();
        Debug.Log("Idle");
    }
}
