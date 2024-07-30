using UnityEngine;

public class WeaponAnimationsOverrider : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private AnimatorOverrideController _override;

    void Start()
    {
        _animator.runtimeAnimatorController = _override;
    }
}
