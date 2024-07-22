using UnityEngine;

public class CrouchState : StateMachineBehaviour
{
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        PlayerMoveStateMachine.Instance.Crouch();
        Debug.Log("Crouch");
    }
}
