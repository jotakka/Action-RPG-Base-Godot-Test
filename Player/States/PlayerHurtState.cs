using ARPG.Player;
using ARPG.Shared;
using Godot;
using System;

public sealed class PlayerHurtState : PlayerStateBase
{
    public PlayerHurtState(PlayerNode player, StatePriority priority = StatePriority.REGULAR)
        : base(player, priority)
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
        _player.HitBoxComponent?.HurtAnimation();
        var enemyHitVelocity = _player.HitBoxComponent?.EnemyHitVelocity ?? Vector2.Zero;
        _player.Velocity = (enemyHitVelocity - _player.Velocity) * _player.KnockBackFactor;
        _player.HealthComponent?.TakeDamage();
        _player.MoveAndCollide(_player.Velocity);
    }
}
