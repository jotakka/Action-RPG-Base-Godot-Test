using System;
using ARPG.Player;
using ARPG.Shared;
using Godot;

public sealed class PlayerIdleState : PlayerStateBase
{
    public PlayerIdleState(PlayerNode player) : base(player)
    {
    }

    public override void Enter()
    {
        _player.WalkAnimationComponent?.PlayIdleAnimation();
        base.Enter();
    }

    public override void Update(double delta)
    {
        var playerInputAction = _player.PlayerInputProcessor?.PlayerInputAction 
            ?? PlayerInputAction.Idle;
        if (playerInputAction != PlayerInputAction.Idle) 
        {
            _player.StateMachine.ChangeState(playerInputAction);
        }
        else
        {
            _player.WalkAnimationComponent?.PlayIdleAnimation();
            _player.MoveAndCollide(Vector2.Zero);
        }
    }
}
