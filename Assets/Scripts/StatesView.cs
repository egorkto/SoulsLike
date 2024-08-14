using System.Collections;
using UnityEngine;

public class StatesView : MonoBehaviour
{
    [SerializeField] private Animator _animator;

    public void View(PlayerState state)
    {
        _animator.CrossFadeInFixedTime(Animator.StringToHash(state.AnimatorStateName), 0.15f);
        StartCoroutine(Animating(state));
    }

    public IEnumerator Animating(PlayerState state)
    {
        yield return new WaitWhile(() => _animator.IsInTransition(0));
        yield return new WaitUntil(() => _animator.GetCurrentAnimatorStateInfo(0).IsName(state.AnimatorStateName));
        yield return new WaitWhile(() => _animator.GetCurrentAnimatorStateInfo(0).normalizedTime < 1);
        state.OnAnimationComplete();
    }
}
