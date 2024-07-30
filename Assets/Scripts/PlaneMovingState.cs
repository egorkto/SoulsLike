using UnityEngine;

public class PlaneMovingState : MoveState
{
    [SerializeField] private PlaneMoveType _type;

    public override void OnEnterState(PlayerMover mover, PlayerStats stats)
    {
        var speed = 0f;
        switch (_type)
        {
            case PlaneMoveType.Stand:
                speed = 0;
                break;
            case PlaneMoveType.Walk:
                speed = stats.WalkSpeed;
                break;
            case PlaneMoveType.Run:
                speed = stats.RunSpeed;
                break;
            case PlaneMoveType.Crouch:
                speed = stats.CrouchSpeed;
                break;
            case PlaneMoveType.FastCrouch:
                speed = stats.FastCrouchSpeed;
                break;
        }
        mover.SetPlaneSpeed(speed);
    }
}

public enum PlaneMoveType
{
    Stand,
    Walk,
    Run,
    Crouch,
    FastCrouch
}
