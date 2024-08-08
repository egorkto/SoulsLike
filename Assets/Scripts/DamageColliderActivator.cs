using UnityEngine;

public class DamageColliderActivator : MonoBehaviour
{
    [SerializeField] private Player _player;

    public void EnableDamageCollider()
    {
        if(_player.Weapon != null)
            _player.Weapon.DamageCollider.gameObject.SetActive(true);
    }

    public void DisableDamageCollider()
    {
        if (_player.Weapon != null)
            _player.Weapon.DamageCollider.gameObject.SetActive(false);
    }

    private void Start()
    {
        DisableDamageCollider();
    }
}
