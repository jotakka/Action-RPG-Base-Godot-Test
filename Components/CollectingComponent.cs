using ARPG.Enemies;
using ARPG.Shared;
using Godot;
using System.Threading.Tasks;

public partial class CollectingComponent : Node
{
	[Export]
	public HitBoxComponent? HitBoxComponent;

	public override void _Ready()
	{
		if (HitBoxComponent is not null)
		{
			HitBoxComponent.AreaEntered += OnHitBoxEnteredAsync;
		}
	}

	private async void OnHitBoxEnteredAsync(Area2D area)
	{
		if (area is CollectableBase collectable)
		{
			await OnCollectedAsync(collectable);
		}
	}


	public virtual async Task OnCollectedAsync(CollectableBase collectable)
	{
		if(collectable.AnimationPlayer is not null)
		{
			if(string.IsNullOrEmpty(collectable.ItemResource?.AnimationOnCollect) is false)
			{
				collectable.AnimationPlayer.Play(collectable.ItemResource.AnimationOnCollect);
				await ToSignal(collectable.AnimationPlayer, AnimationPlayer.SignalName.AnimationFinished);
			}
		}
		collectable.QueueFree();
	}

}
