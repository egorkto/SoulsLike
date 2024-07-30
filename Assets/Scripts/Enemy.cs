using UnityEngine;

public class Enemy : MonoBehaviour, IDamagable
{
    [SerializeField] private Health _health;

    public void GetDamage(int damage)
    {
        Debug.Log("Get damage: " + damage);
        _health.GetDamage(damage);
    }
}
