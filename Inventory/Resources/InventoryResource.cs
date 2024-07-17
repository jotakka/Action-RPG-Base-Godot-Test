using Godot;
using Godot.Collections;

[GlobalClass]
public partial class InventoryResource : Resource
{
	[Export]
	public Dictionary<string, InventorySlotResource> InventorySlots = new();

	[Export]
	public int MaxSize = 15;

	[Signal]
	public delegate void ItemUpdatedSignalEventHandler();

	public System.Collections.Generic.ICollection<InventorySlotResource> InvetoryItems
	{
		get
		{
			return InventorySlots.Values;
		}
	}

	public void AddItem(InventoryItemResource item)
	{
		GD.Print($"Item added: {item.Name}");
		if (InventorySlots.ContainsKey(item.Name))
		{
			InventorySlots[item.Name].Amount++;
		}
		else
		{
			if (InventorySlots.Count >= MaxSize)
			{
				return;
			}

			InventorySlots[item.Name] = new InventorySlotResource
			{
				InventoryItem = item,
				Amount = 1
			};
		}
		EmitSignal(nameof(ItemUpdatedSignal));
	}

	public void RemovedItem(InventoryItemResource item)
	{
		GD.Print($"Item removed: {item.Name}");
		if (InventorySlots.ContainsKey(item.Name))
		{
			InventorySlots[item.Name].Amount--;
		}
		EmitSignal(nameof(ItemUpdatedSignal));
	}
}
