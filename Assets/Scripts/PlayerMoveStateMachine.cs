using UnityEngine;

public class PlayerMoveStateMachine : MonoBehaviour
{
    public static PlayerMoveStateMachine Instance => _instance;

    [SerializeField] private PlayerMover _playerMover;
    [SerializeField] private PlayerStats _playerStats;

    private static PlayerMoveStateMachine _instance;

    public void EnterState(IMoveState state)
    {
        state.OnEnterState(_playerMover, _playerStats);
    }

    public void ExitState(IMoveState state)
    {
        state.OnExitState(_playerMover);
    }

    private void Awake()
    {
        if (_instance == null) 
            _instance = this;
        else
            Destroy(gameObject);
    }
}
