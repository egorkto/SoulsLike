using UnityEngine;

public class JumpState : StateMachineBehaviour
{
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        PlayerMoveStateMachine.Instance.Jump();
        Debug.Log("Jump");
    }
}
