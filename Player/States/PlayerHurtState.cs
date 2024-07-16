﻿using ARPG.Player;
using Godot;
using System;

public sealed class PlayerHurtState : PlayerStateBase
{
    public PlayerHurtState(PlayerNode player) : base(player)
    {
    }

    public override void Enter()
    {
        KnockBack();
        base.Enter();
    }

    public override void Update(double delta)
    {
        var playerInputAction = _player.PlayerInputProcessor?.PlayerInputAction
            ?? PlayerInputAction.Idle;
        _player.StateMachine.ChangeState(playerInputAction);

    }

    private void KnockBack()
    {
        _player.HurtBoxComponent?.HurtAnimation();
        var enemyHitVelocity = _player.HurtBoxComponent?.EnemyHitVelocity ?? Vector2.Zero;
        _player.Velocity = (enemyHitVelocity - _player.Velocity) * _player.KnockBackFactor;
        _player.HealthComponent?.TakeDamage();
        _player.MoveAndCollide(_player.Velocity);
    }
}
