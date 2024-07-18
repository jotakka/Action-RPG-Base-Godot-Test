using ARPG.Enemies;
using ARPG.Shared;
using Godot;

public partial class Octopus : CharacterBody2D
{
	private EnemyCharacterStates _enemyCharacterStates;
	private CharacterAnimationController _animationController;

	[Export]
	public float Speed = 0.5f;
	[Export]
	public HitBoxComponent HitBoxComponent { get; set; } = null!;
	[Export]
	public Marker2D EndPoint;

	public override void _Ready()
	{
		_animationController = new(
			GetNode<AnimatedSprite2D>("AnimatedSprite2D"),
			null
		);
		HitBoxComponent.IsEnemyNode = true;
		//_enemyCharacterStates = new(
		//	Position,
		//	EndPoint.GlobalPosition,
		//	Speed);
		HitBoxComponent.HurtByEnemySignal += () => {
			QueueFree();
		};
	}

	public override void _PhysicsProcess(double delta)
	{
		//_enemyCharacterStates.UpdateMovementStates(Position);
		//Velocity = _enemyCharacterStates.Velocity;
		//var movementDirection = _enemyCharacterStates.MovementDirection;

		//_animationController.SetWalkAnimation(movementDirection);
		MoveAndCollide(Vector2.Zero);
	}
}
