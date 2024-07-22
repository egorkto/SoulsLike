using UnityEngine;

public class Player : MonoBehaviour
{
    public CharacterController Controller => _controller;
    public PlayerState State => _state;

    [SerializeField] private CharacterController _controller;

    private PlayerState _state = PlayerState.Move;

    public bool TryInterract()
    {
        if(_state != PlayerState.Attack && _controller.isGrounded)
        {
            _state = PlayerState.Interract;
            return true;
        }
        return false;
    }

    public bool TryAttack()
    {
        if(_state != PlayerState.Interract)
        {
            _state = PlayerState.Attack;
            return true;
        }
        return false;
    }

    public void StartMoving()
    {
        _state = PlayerState.Move;
    }
}

public enum PlayerState
{
    Move,
    Attack,
    Interract
}