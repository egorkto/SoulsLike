using System.Collections;
using UnityEngine;

public class StateAnimator : MonoBehaviour
{
    [SerializeField] private Animator _animator;

    public void Animate(IInterruptedState state)
    {
        _animator.CrossFadeInFixedTime(Animator.StringToHash(state.AnimatorTrigger), 0.15f);
    }

    public void Animate(IUninterruptedState state)
    {
        _animator.CrossFadeInFixedTime(Animator.StringToHash(state.AnimatorTrigger), 0.15f);
        StartCoroutine(Waiting(state));
    }

    public IEnumerator Waiting(IUninterruptedState state)
    {
        yield return new WaitWhile(() => _animator.IsInTransition(0));
        yield return new WaitUntil(() => _animator.GetCurrentAnimatorStateInfo(0).IsName(state.AnimatorTrigger));
        yield return new WaitWhile(() => _animator.GetCurrentAnimatorStateInfo(0).normalizedTime < 1);
        state.Complete();
    }
}
