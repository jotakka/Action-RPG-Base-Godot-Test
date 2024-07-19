using ARPG.Enemies;
using ARPG.Shared;
using Godot;
using System;
public partial class EnemyBase : CharacterBody2D
{
	[Export]
	public HitBoxComponent HitBoxComponent { get; set; } = null!;
	[Export]
	public AnimationLibrary AnimationLibraryResource { get; set; } = null!;
	[Export]
	public EnemyHurtBoxComponent HurtBoxComponent { get; set; } = null!;
	[Export]
	public Sprite2D Sprite2D { get; set; } = null!;
	[Export]
	public CollisionShape2D EnvCollisionShape { get; set; } = null!;
	[Export]
	public AnimationPlayer AnimationPlayer { get; set; } = null!;
	[Export]
	public WalkAnimationComponent WalkAnimationComponent { get; set; } = null!;
	[Export]
	public EnemyDeathAnimationComponent DeathAnimationComponent { get; set; } = null!;
	[Export]
	public float Speed { get; set; } = 0.5f;
	[Export]
	public Marker2D EndPoint;

	private bool _isHurt = false;
	private EnemyCharacterStates _enemyCharacterStates;
	private string _animagionLibName = Guid.NewGuid().ToString();
	private CharacterAnimationController _animationController;

	public override void _Ready()
	{
		HitBoxComponent.IsEnemyNode = true;
		AnimationPlayer.AddAnimationLibrary(_animagionLibName, AnimationLibraryResource);
		_enemyCharacterStates = new(
			Position,
			EndPoint.GlobalPosition,
			Speed);

		if(DeathAnimationComponent is not null)
		{
			DeathAnimationComponent.DeathAnimationFinishedSignal += OnDeathAnimationFinished;
		}

		HitBoxComponent.HurtByEnemySignal += OnHurt;
	}

	public override void _PhysicsProcess(double delta)
	{
		if(_isHurt)
		{
			return;
		}
		_enemyCharacterStates.UpdateMovementStates(Position);
		Velocity = _enemyCharacterStates.Velocity;
		var movementDirection = _enemyCharacterStates.MovementDirection;

		WalkAnimationComponent.PlayWalkAnimation(_animagionLibName, movementDirection);

		MoveAndCollide(Velocity);
	}

	private void OnHurt()
	{
		if(DeathAnimationComponent is not null)
		{
			_isHurt = true;

			DisableCollisionWithPlayer();
			HurtBoxComponent.Disable();
			DeathAnimationComponent.PlayDeathAnimation();
		}
		else
		{
			QueueFree();
		}
	}

	private void DisableCollisionWithPlayer()
	{
		SetCollisionLayerValue(
			(int)CollisionLayerNumber.Enemy,
			false
		);
	}

	private void OnDeathAnimationFinished()
	{
		_isHurt = false;
		QueueFree();
	}
}

