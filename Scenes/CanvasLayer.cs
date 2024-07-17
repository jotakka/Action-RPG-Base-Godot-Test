using ARPG.Shared;
using Godot;

public partial class CanvasLayer : Godot.CanvasLayer
{
	[Export]
	public string InventoryGuiNode = "InventoryGui";

	private InventoryGui _inventroyGui;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		_inventroyGui = GetNode<InventoryGui>(InventoryGuiNode);
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}


	public override void _Input(InputEvent @event)
	{
		if (@event.IsActionPressed(UserInput.ToggleInventory.Value))
		{
			_inventroyGui.ToggleInventoryGui();
		}
		base._Input(@event);
	}
}
