public abstract class PlayerState : IPlayerState
{
    public abstract string AnimatorStateName { get; }

    protected IPlayerStateMachine StateMachine => _stateMachine;

    private readonly IPlayerStateMachine _stateMachine;

    public PlayerState(IPlayerStateMachine statesMachine)
    {
        _stateMachine = statesMachine;
    }

    public abstract void OnEnter();
    
    public virtual void OnAnimationComplete() { }

    public virtual void StartMove() { }

    public virtual void StopMove() { }

    public virtual void StartRun() { }

    public virtual void StopRun() { }

    public virtual void Crouch() { }

    public virtual void Dash() { }

    public virtual void Jump() { }

    public virtual void Fall() { }

    public virtual void Land() { }

    public virtual void Attack() { }

    public virtual void Interact() { }
}