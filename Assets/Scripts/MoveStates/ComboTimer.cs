using System;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class ComboTimer : MonoBehaviour
{
    public event Action Elapsed;

    [SerializeField] private float _waitingAttackSeconds;

    private Coroutine _waitingCoroutine;

    public void StartTimer() 
    {
        if(_waitingCoroutine == null)
            _waitingCoroutine = StartCoroutine(Waiting());
        else
            Debug.LogError("Timer is already started");
    }

    public void StopTimer() 
    {
        if(_waitingCoroutine == null)
            Debug.LogError("There is no active timer");
        else 
        {
            StopCoroutine(_waitingCoroutine);
            _waitingCoroutine = null;
        }
    }

    private IEnumerator Waiting() 
    {
        yield return new WaitForSeconds(_waitingAttackSeconds);
        Elapsed?.Invoke();
        _waitingCoroutine = null;
    }
}