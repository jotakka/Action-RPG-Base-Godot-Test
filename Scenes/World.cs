using Godot;

public partial class World : Node2D
{
	[Export]
	public PlayerNode? PlayerNode;
	[Export]
	public InventoryGui? InventoryGui;
	[Export]
	public HeartsContainer? HeartsContainer;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		if (HeartsContainer is not null && PlayerNode is not null)
		{
			HeartsContainer.SetMaxHearts(
				PlayerNode.HealthComponent?.MaxHealth ?? 0
				);
			PlayerNode.HealthComponent!.HealthChangedSignal += HeartsContainer.UpdateHearts;
		}

		if (InventoryGui is not null)
		{
			InventoryGui.InventoryOpened += OnInventoryOpened;
			InventoryGui.InventoryClosed += OnInventoryClosed;
			InventoryGui.InventoryResource.ItemUpdatedSignal += InventoryGui.OnUpdateInventoryItems;
		}
	}

	private void OnInventoryOpened()
	{
		GetTree().Paused = true;
	}

	private void OnInventoryClosed()
	{
		GetTree().Paused = false;
	}
}
