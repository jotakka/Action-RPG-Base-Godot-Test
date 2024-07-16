using ARPG.Shared;
using ARPG.Util;
using Godot;
public partial class AttackComponent : Node
{
	[Export]
	public AnimationPlayer? AnimationPlayer;

	[Export]
	public int Damage = 1;

	public bool IsAttacking { get; private set; } = false;

	private string? _lastAnimationName;

	public override void _Ready()
	{
		if(AnimationPlayer is not null)
		{
			AnimationPlayer.AnimationFinished += OnAnimationFinished;
		}
	}

	public void Attack(AnimationDirection directionString)
	{
		IsAttacking = true;
		var animationName = AnimationType.Attack + "_" + directionString;
		AnimationPlayer?.Play(animationName);
		_lastAnimationName = animationName;
	}

	public void Attack(Vector2 direction)
	{
		IsAttacking = true;
		var directionString = Helpers.GetAnimationDirectionString(direction);
		var animationName = AnimationType.Attack + "_" + directionString;
		AnimationPlayer?.Play(animationName);
		_lastAnimationName = animationName;
	}

	private void OnAnimationFinished(StringName animationName)
	{
		if (animationName == _lastAnimationName )
		{
			IsAttacking = false;
			_lastAnimationName = animationName;
		}
	}
}
