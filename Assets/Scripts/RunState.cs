using UnityEngine;

public class RunState : StateMachineBehaviour
{
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        PlayerMoveStateMachine.Instance.Run();
        Debug.Log("Run");
    }
}
