using Godot;

[GlobalClass]
public partial class InventoryItemResource : Resource
{
	[Export]
	public string Name { get; set; } = "";
	[Export]
	public Texture2D Texture { get; set; } = null!;
	[Export]
	public string? AnimationOnCollect { get; set; } = null;
}
