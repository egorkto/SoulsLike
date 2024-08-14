using UnityEngine;

public class WeaponView : MonoBehaviour
{
    [SerializeField] Weapon _weapon;

    public void HideWeapon()
    {
        _weapon.gameObject.SetActive(false);
    }

    public void ShowWeapon()
    {
        _weapon.gameObject.SetActive(true);
    }
}