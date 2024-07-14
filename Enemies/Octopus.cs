using ARPG.Enemies;
using ARPG.Player;
using ARPG.Shared;
using Godot;
using System;

public partial class Octopus : CharacterBody2D
{
	private EnemyCharacterStates _enemyCharacterStates;
	private CharacterAnimationController _animationController;
	
	[Export]
	public float Speed = 0.5f;
	[Export]
	public Marker2D EndPoint;

	public override void _Ready()
	{
		_animationController = new(
			GetNode<AnimatedSprite2D>("AnimatedSprite2D"),
			null
		);
		_enemyCharacterStates = new(
			Position,
			EndPoint.GlobalPosition,
			Speed);
	}

	public override void _PhysicsProcess(double delta)
	{
		_enemyCharacterStates.UpdateMovementStates(Position);
		Velocity = _enemyCharacterStates.Velocity;
		var movementDirection = _enemyCharacterStates.MovementDirection;

		_animationController.SetWalkAnimation(movementDirection);
		MoveAndCollide(Velocity);
	}
}
