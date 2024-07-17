using Godot;

public partial class SlotGui : Panel
{
	[Export]
	public Sprite2D? BackgroundSprite { get; set; }
	[Export]
	public Sprite2D? ItemSprite { get; set; }
	[Export]
	public Label? ItemCountLabel { get; set; }

	public override void _Ready()
	{
		BackgroundSprite!.Frame = 0;
		ItemSprite!.Hide();
		ItemCountLabel!.Hide();
	}

	public void Update(InventorySlotResource? inventorySlot)
	{
		if (inventorySlot is null)
		{
			BackgroundSprite!.Frame = 0;
			ItemSprite?.Hide();
			ItemCountLabel?.Hide();
		}
		else
		{
			ItemSprite?.Show();
			ItemCountLabel?.Show();
			BackgroundSprite!.Frame = 1;
			ItemCountLabel!.Text = inventorySlot.Amount.ToString();
			ItemSprite!.Texture = inventorySlot.InventoryItem.Texture;
		}
	}
}
