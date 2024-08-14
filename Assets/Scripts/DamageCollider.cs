using System;
using UnityEngine;

public class DamageCollider : MonoBehaviour
{
    public event Action<IDamagable> Hit;

    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log("Hit: " + other.gameObject.name);
        if(other.TryGetComponent<IDamagable>(out var damagable))
            Hit?.Invoke(damagable);
    }
}