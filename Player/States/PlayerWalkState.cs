using System;
using ARPG.Player;
using Godot;

public sealed class PlayerWalkState : PlayerStateBase
{
    public PlayerWalkState(PlayerNode player) : base(player)
    {
    }

    public override void Enter()
    {
        //UpdateWalking();
        base.Enter();
    }

    public override void Update(double delta)
    {
        var playerInputAction = _player.PlayerInputProcessor?.PlayerInputAction
            ?? PlayerInputAction.Idle;
        if (playerInputAction != PlayerInputAction.Walk)
        {
            _player.StateMachine.ChangeState(playerInputAction);
        }
        else
        {
            UpdateWalking();
        }
    }

    private void UpdateWalking()
    {
        var direction = _player.PlayerInputProcessor?.MovementDirection ?? Vector2.Zero;
        _player.WalkAnimationComponent?.PlayWalkAnimation(direction);
        _player.Velocity = _player.PlayerInputProcessor!.MovementDirection * _player.DefaultSpeed;
        _player.MoveAndCollide(_player.Velocity);
    }
}
