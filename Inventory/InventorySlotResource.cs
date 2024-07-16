using Godot;


[GlobalClass]
public partial class InventorySlotResource : Resource
{
	[Export]
	public InventoryItemResource InventoryItem { get; set; }

	[Export]
	public int Amount { get; set; }
}
