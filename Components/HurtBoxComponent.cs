using ARPG.Enemies;
using ARPG.Shared;
using Godot;
using System.Threading.Tasks;

public partial class HurtBoxComponent : Area2D
{
	[Export]
	public CollisionShape2D? HurtBoxShape;
	[Export]
	public AnimationPlayer? HurtEffectPlayer;
	[Export]
	public Timer? HurtTimer;

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

		if(HurtEffectPlayer is not null)
		{
			HurtEffectPlayer.Play(EffectType.RESET.Value);
		}
	}

	public override void _PhysicsProcess(double delta)
	{

		if (HurtBoxShape is null) return;
		if (IsHurt is false)
		{
			foreach (var collisionArea in this.GetOverlappingAreas())
			{
				if (collisionArea.Name == EnemyConsts.HitBoxName)
				{
					EmitSignal(nameof(HurtByEnemySignal));
					HurtByEnemy(collisionArea);
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
