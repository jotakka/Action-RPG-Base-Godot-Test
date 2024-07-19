using ARPG.Enemies;
using Godot;

public partial class EnemyDeathAnimationComponent: Sprite2D
{
	[Export]
	public Sprite2D EnemyMainSprite { get; set; } = null!;
	[Export]
	public AnimationPlayer AnimationPlayer { get; set; } = null!;
	[Signal]
	public delegate void DeathAnimationFinishedSignalEventHandler();

	public override void _Ready()
	{
		AnimationPlayer.AnimationFinished += (animationName)=> OnAnimationFinished(animationName);
		Visible = false;
	}

	public void PlayDeathAnimation()
	{
		EnemyMainSprite.Visible = false;
		Visible = true;
		AnimationPlayer.Play(SharedEnemyAnimation.Death.Value);
	}

	private void OnAnimationFinished(string animationName)
	{
		if (animationName == SharedEnemyAnimation.Death)
		{
			Visible = false;
			EnemyMainSprite.Visible = true;
			EmitSignal(nameof(DeathAnimationFinishedSignal));
		}
	}
}
