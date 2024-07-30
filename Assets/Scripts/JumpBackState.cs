public class JumpBackState : MoveState
{
    public override void OnEnterState(PlayerMover mover, PlayerStats stats)
    {
        mover.SetPlaneSpeed(stats.JumpBackForce);
        mover.SetRotating(false);
    }

    public override void OnExitState(PlayerMover mover)
    {
        mover.SetRotating(true);
    }
}
