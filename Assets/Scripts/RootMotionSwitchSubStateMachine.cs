using UnityEngine;

public class RootMotionSwitchSubStateMachine : StateMachineBehaviour
{
    [SerializeField] private bool _enableRootMotion = true;

    public override void OnStateMachineEnter(Animator animator, int stateMachinePathHash)
    {
        animator.applyRootMotion = _enableRootMotion;
    }
}
