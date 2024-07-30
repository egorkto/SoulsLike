public class RollState : MoveState
{
    public override void OnEnterState(PlayerMover mover, PlayerStats stats)
    {
        mover.SetPlaneSpeed(stats.RollForce);
        mover.SetRotating(false);
    }

    public override void OnExitState(PlayerMover mover)
    {
        mover.SetRotating(true);
    }
}
