public class JumpState : MoveState
{
    public override void OnEnterState(PlayerMover mover, PlayerStats stats)
    {
        mover.Jump(stats.JumpForce);
    }
}
