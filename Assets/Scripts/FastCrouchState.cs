using UnityEngine;

public class FastCrouchState : StateMachineBehaviour
{
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        PlayerMoveStateMachine.Instance.FastCrouch();
        Debug.Log("FastCrouch");
    }
}
