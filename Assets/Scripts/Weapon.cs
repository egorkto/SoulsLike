using UnityEngine;

public class Weapon : MonoBehaviour
{
    public DamageCollider DamageCollider => _damageCollider;

    [SerializeField] private DamageCollider _damageCollider;
    [SerializeField] private int _damage;

    private void OnEnable()
    {
        _damageCollider.Hit += OnHit;
    }

    private void OnDisable()
    {
        _damageCollider.Hit -= OnHit;
    }

    private void OnHit(IDamagable damagable)
    {
        damagable.GetDamage(_damage);
    }
}
