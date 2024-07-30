public interface IMoveState
{
    public void OnEnterState(PlayerMover mover, PlayerStats stats);
    public void OnExitState(PlayerMover mover);
}
