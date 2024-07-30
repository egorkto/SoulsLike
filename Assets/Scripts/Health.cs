using System;
using UnityEngine;

public class Health : MonoBehaviour
{
    public event Action Died;
    public event Action<int, int> HealthChanged;

    [SerializeField] private int _startHealth;

    private int _currentHealth;

    public void GetDamage(int damage)
    {
        _currentHealth -= damage;
        HealthChanged?.Invoke(_startHealth, _currentHealth);
        if (_currentHealth < 0) 
            Died?.Invoke();
    }

    private void Start()
    {
        _currentHealth = _startHealth;
        HealthChanged?.Invoke(_startHealth, _currentHealth);
    }
}
