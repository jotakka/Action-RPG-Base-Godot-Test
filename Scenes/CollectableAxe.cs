using Godot;
using System;
using System.Threading.Tasks;

public partial class CollectableAxe : CollectableBase
{
	[Export]
	public const string SpinAnimation = "spin";
	private AnimationPlayer _animationPlayer;

	public override void _Ready()
	{
		_animationPlayer = GetNode<AnimationPlayer>(nameof(AnimationPlayer));
	}

	public override async Task OnCollectedAsync(InventoryResource inventory)
	{
		_animationPlayer.Play(SpinAnimation);
		await ToSignal(_animationPlayer, AnimationPlayer.SignalName.AnimationFinished);
		await base.OnCollectedAsync(inventory);
	}
}
