using Godot;
using Godot.Collections;
using System.Collections.Generic;
using System.Linq;

public partial class InventoryGui : Control
{
	[Export]
	public InventoryResource InventoryResource { get; set; } = null!;
	[Export]
	private GridContainer GridContainer { get; set; } = null!;
	[Signal]
	public delegate void InventoryClosedEventHandler();
	[Signal]
	public delegate void InventoryOpenedEventHandler();

	private IEnumerable<SlotGui> _inventorySlots = Enumerable.Empty<SlotGui>();
	private bool _isOpen = false;


	public override void _Ready()
	{
		_inventorySlots = GridContainer!
			.GetChildren()
			.OfType<SlotGui>();

		InventoryResource.ItemUpdatedSignal += OnUpdateInventoryItems;

		Hide();
	}

	public void OnUpdateInventoryItems()
	{
		GD.Print("Inventory updated signal received");
		var i = 0;
		foreach (var item in InventoryResource.InvetoryItems)
		{
			_inventorySlots.ElementAt(i).Update(item);
			i++;
		}
		for (; i < _inventorySlots.Count(); i++)
		{
			_inventorySlots.ElementAt(i).Update(null);
		}
	}

	public void ToggleInventoryGui()
	{
		_isOpen = !_isOpen;

		if (_isOpen)
		{
			Show();
			EmitSignal(nameof(InventoryOpened));
		}
		else
		{
			Hide();
			EmitSignal(nameof(InventoryClosed));
		}
	}
}

