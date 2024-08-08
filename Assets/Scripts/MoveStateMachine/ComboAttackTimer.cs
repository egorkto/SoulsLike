using System.Collections;
using UnityEngine;

public class ComboAttackTimer : MonoBehaviour
{
    [SerializeField] private float _waitAttackTime;

    public void WaitForNextAttack(IComboAttackState state)
    {
        StopAllCoroutines();
        StartCoroutine(Waiting(state));
    }

    private IEnumerator Waiting(IComboAttackState state)
    {
        yield return new WaitForSeconds(_waitAttackTime);
        state.StopCombo();
    }
}
