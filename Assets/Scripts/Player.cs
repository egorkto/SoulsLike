using UnityEngine;

public class Player : MonoBehaviour
{
    public Weapon Weapon => _weapon;

    [SerializeField] private Weapon _weapon;
}