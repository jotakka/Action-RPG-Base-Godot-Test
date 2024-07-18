using ARPG.Shared;
using Godot;

public partial class HitBoxComponent : Area2D
{
	[Export]
	public CollisionShape2D HitBoxShape { get; set; } = null!;
	[Export]
	public AnimationPlayer? HurtEffectPlayer { get; set; }
	[Export]
	public Timer? HurtTimer { get; set; }
	[Export]
	public bool IsEnemyNode { get; set; } = false;

	[Signal]
	public delegate void HurtByEnemySignalEventHandler();

	public bool IsHurt { get; private set; } = false;

	public Vector2 EnemyHitVelocity { get; private set; } = Vector2.Zero;

	public override void _Ready()
	{
		if (HurtTimer is not null)
		{
			HurtTimer.Timeout += ResetHurtState;
		}

		if (HurtEffectPlayer is not null)
		{
			HurtEffectPlayer.Play(EffectType.RESET.Value);
		}
	}

	public override void _PhysicsProcess(double delta)
	{

		if (HitBoxShape is null) return;
		if (IsHurt is false)
		{
			foreach (var collisionArea in this.GetOverlappingAreas())
			{
				if (IsEnemyNode is false)
				{
					if (collisionArea is EnemyHurtBoxComponent)
					{
						EmitSignal(nameof(HurtByEnemySignal));
						HurtByEnemy(collisionArea);
					}
				}
				else if (collisionArea is WeaponBase)
				{
					EmitSignal(nameof(HurtByEnemySignal));
				}
			}
		}
	}

	private void HurtByEnemy(Area2D enemyArea)
	{
		IsHurt = true;
		EnemyHitVelocity = enemyArea.GetParent<CharacterBody2D>().Velocity;
	}

	public void HurtAnimation()
	{
		HurtEffectPlayer?.Play(EffectType.HurtBlink.Value);
		HurtTimer?.Start();
	}

	private void ResetHurtState()
	{
		HurtEffectPlayer?.Play(EffectType.RESET.Value);
		IsHurt = false;
	}
}
