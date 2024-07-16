using Godot;

[GlobalClass]
public partial class InventoryItemResource : Resource
{
	[Export]
	public string Name { get; set; } = "";
	[Export]
	public Texture2D Texture { get; set; }
	[Export]
	public string? AnimationOnCollect { get; set; } = null;
}
