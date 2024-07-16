using ARPG.Player;
using ARPG.Shared;
using Godot;

public partial class PlayerInputProcessor : Node
{
	public PlayerInputAction PlayerInputAction { get; private set; } = PlayerInputAction.Idle;

	public Vector2 MovementDirection { get; private set; } = Vector2.Zero;

	public bool IsAttacking { get; private set; }

	public override void _PhysicsProcess(double delta)
	{
		IsAttacking = Input.IsActionJustPressed(UserInput.Attack.Value);
		MovementDirection = GetNewMovementDirection();
		PlayerInputAction = GetPlayerInputAction();
	}

	private PlayerInputAction GetPlayerInputAction()
	{
		if (IsAttacking)
		{
			return PlayerInputAction.Attack;
		}
		else if (MovementDirection != Vector2.Zero)
		{
			return PlayerInputAction.Walk;
		}
		else
		{
			return PlayerInputAction.Idle;
		}
	}

	private Vector2 GetNewMovementDirection()
	{
		Vector2 direction = new();
		direction.X = Input.GetActionStrength(UserInput.MoveRight.Value) - Input.GetActionStrength(UserInput.MoveLeft.Value);
		direction.Y = Input.GetActionStrength(UserInput.MoveDown.Value) - Input.GetActionStrength(UserInput.MoveUp.Value);

		// If input is digital, normalize it for diagonal movement
		if (Mathf.Abs(direction.X) == 1 && Mathf.Abs(direction.Y) == 1)
		{
			direction = direction.Normalized();
		}

		return direction;
	}
}
