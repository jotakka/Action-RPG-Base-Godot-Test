using Godot;
using System;

public partial class World : Node2D
{
	[Export]
	public string PlayerNodePath = "Player";
	[Export]
	public string HeartsContainerNodePath = "CanvasLayer/HeartsContainer";
	[Export]
	public string InventoryGuiNodePath = "CanvasLayer/InventoryGui";


	private HeartsContainer _heartsContainer;
	private InventoryGui _inventoryGui;
	private Player _player;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		_heartsContainer = GetNode<HeartsContainer>(HeartsContainerNodePath);
		_player = GetNode<Player>(PlayerNodePath);
		_heartsContainer.SetMaxHearts(_player.MaxHealth);
		_inventoryGui = GetNode<InventoryGui>(InventoryGuiNodePath);


		_inventoryGui.InventoryOpened += OnInventoryOpened;
		_inventoryGui.InventoryClosed += OnInventoryClosed;
		_player.HealthChanged += _heartsContainer.UpdateHearts;
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
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
