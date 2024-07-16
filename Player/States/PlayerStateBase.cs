using ARPG.Shared;
using Godot;


public abstract class PlayerStateBase : IState
{
    protected readonly PlayerNode _player;

    protected PlayerStateBase(PlayerNode player)
    {
        _player = player;
    }

    public virtual void Enter()
    {
        GD.PrintS($"State entered: {this.GetType().Name}");
    }
    public virtual void Exit()
    {
        GD.PrintS($"State exited: {this.GetType().Name}");
    }

    public virtual void Update(double delta)
    {
    }
}

