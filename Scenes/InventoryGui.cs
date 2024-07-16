using Godot;
using System.Collections.Generic;
using System.Linq;

public partial class InventoryGui : Control
{
	[Signal]
	public delegate void InventoryClosedEventHandler();
	[Signal]
	public delegate void InventoryOpenedEventHandler();


	private InventoryResource _inventoryResource;
	private IEnumerable<SlotGui> _inventorySlots;
	private bool isOpen = false;

	public override void _Ready()
	{
		//_inventoryResource = (InventoryResource)ResourceLoader
		//	.Load("res://Inventory/Items/player_inventroy_resource.tres");
		//_inventorySlots = (GetNode<GridContainer>("NinePatchRect/GridContainer"))
		//	.GetChildren()
		//	.OfType<SlotGui>();
		//_inventoryResource.SlotItemAdded += () =>
		//{
		//	GD.Print("Item Added Signal");
		//	UpdateItems();
		//};

		//UpdateItems();
		//Hide();
	}

	private void UpdateItems()
	{
		//var i = 0;
		//foreach (var slotItem in _inventoryResource.InventorySlots.Values)
		//{
		//	_inventorySlots.ElementAt(i).Update(slotItem);
		//	i++;
		//}
		//for (; i < _inventorySlots.Count(); i++)
		//{
		//	_inventorySlots.ElementAt(i).Update(null);
		//}
	}

	public void ToggleInventory()
	{
		//isOpen = !isOpen;

		//if (isOpen)
		//{
		//	Show();
		//	EmitSignal(nameof(InventoryOpened));
		//}
		//else
		//{
		//	Hide();
		//	EmitSignal(nameof(InventoryClosed));
		//}
	}
}
