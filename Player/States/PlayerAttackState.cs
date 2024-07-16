using ARPG.Player;
using ARPG.Shared;
using Godot;
using System;

public sealed class PlayerAttackState : PlayerStateBase
{
    public PlayerAttackState(PlayerNode player) : base(player)
    {
    }

    public override void Enter()
    {
        var direction = _player.PlayerInputProcessor?.MovementDirection ?? Vector2.Zero;

        if (direction == Vector2.Zero)
        {
            var lastIdleDirection = _player.WalkAnimationComponent
                ?.LastFacingDirection 
                ?? AnimationDirection.Down;
            _player.AttackComponent?.Attack(lastIdleDirection);
        }
        else
        {
            _player.AttackComponent?.Attack(direction);
        }

        _player.WeaponComponent?.ShowWeapon();
        base.Enter();
    }

    public override void Update(double delta)
    {
        if(_player.AttackComponent?.IsAttacking ?? false)
        {
            return;
        }
        _player.WeaponComponent?.HideWeapon();

        var playerInputAction = _player.PlayerInputProcessor?.PlayerInputAction
            ?? PlayerInputAction.Idle;
        _player.StateMachine.ChangeState(playerInputAction);                                                                                                        
    }
}
