using Godot;
using System;
using System.Threading.Tasks;

public partial class CollectableBase : Area2D
{
	[Export]
	public InventoryItemResource ItemResource { get; set; }
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

	public virtual async Task OnCollectedAsync(InventoryResource inventory)
	{
		inventory.ItemAdded(ItemResource);
		QueueFree();
	}
}
