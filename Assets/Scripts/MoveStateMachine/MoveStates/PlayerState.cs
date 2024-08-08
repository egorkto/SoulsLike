public abstract class PlayerState : IPlayerState
{
    public abstract string AnimatorTrigger { get; }

    protected IMoveStateMachine StateMachine => _stateMachine;
    protected IPlayerMoveStats Stats => _stats;
    protected PlayerMover Mover => _mover;

    private readonly IMoveStateMachine _stateMachine;
    private readonly IPlayerMoveStats _stats;
    private readonly PlayerMover _mover;

    public PlayerState(IMoveStateMachine stateMachine)
    {
        _stateMachine = stateMachine;
        _stats = _stateMachine.Stats;
        _mover = _stateMachine.Mover;
    }

    public void Enter()
    {
        if(!TryTransition())
        {
            OnEnter();
            Animate();
        }
    }

    protected abstract void OnEnter();

    protected virtual bool TryTransition() { return false; }

    protected virtual void Animate() { }

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