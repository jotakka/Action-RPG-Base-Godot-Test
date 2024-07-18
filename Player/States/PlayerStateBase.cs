using ARPG.Shared;
using Godot;
using System.Security.Cryptography.X509Certificates;


public abstract class PlayerStateBase : IState
{
    public StatePriority Priority { get; }

    public bool AllowInterruption { get; protected set; } = true;

    protected readonly PlayerNode _player;

    protected PlayerStateBase(PlayerNode player, StatePriority priority = StatePriority.REGULAR)
    {
        _player = player;
        Priority = priority;
    }

    public virtual void Enter()
    {
    }
    public virtual void Exit()
    {
    }

    public virtual void Update(double delta)
    {
    }
}

