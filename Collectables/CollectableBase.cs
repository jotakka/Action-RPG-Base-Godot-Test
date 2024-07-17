using Godot;
using System.Threading.Tasks;

public partial class CollectableBase : Area2D
{
	[Export]
	public InventoryItemResource? ItemResource { get; set; }

	[Export]
	public Sprite2D? Sprite2D { get; set; }

	[Export]
	public CollisionShape2D? CollectingShape { get; set; }

	[Export]
	public AnimationPlayer? AnimationPlayer;
}
	
