using Godot;
using System;

public partial class SlotGui : Panel
{
	[Export]
	public string BackgroundNodePath { get; set; } = "Background";
	[Export]
	public string ItemNodePath { get; set; } = "CenterContainer/Panel/Item";
	[Export]
	public string ItemCountLabelNodePath { get; set; } = "CenterContainer/Panel/Label";
	
	private Sprite2D _backgroundSprite;
	private Sprite2D _itemSprite;
	private Label _itemCountLabel;
	
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		_backgroundSprite = GetNode<Sprite2D>(BackgroundNodePath);
		_itemSprite = GetNode<Sprite2D>(ItemNodePath);
		_itemCountLabel= GetNode<Label>(ItemCountLabelNodePath);
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

	public void Update(InventorySlotResource inventorySlot)
	{
		if (inventorySlot is null)
		{
			_backgroundSprite.Frame = 0;
			_itemSprite.Visible = false;
			_itemCountLabel.Visible = false;
			return;
		}
		else
		{
			_backgroundSprite.Frame = 1;
			_itemSprite.Visible = true;
			_itemCountLabel.Visible = true;
			_itemCountLabel.Text = inventorySlot.Amount.ToString();
			_itemSprite.Texture = inventorySlot.InventoryItem.Texture;
		}
	}
}
