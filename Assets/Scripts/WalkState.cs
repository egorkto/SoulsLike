using UnityEngine;

public class WalkState : StateMachineBehaviour
{
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        PlayerMoveStateMachine.Instance.Walk();
        Debug.Log("Walk");
    }
}
