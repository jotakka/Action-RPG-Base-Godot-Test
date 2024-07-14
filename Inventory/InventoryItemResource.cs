using Godot;
using System;

[GlobalClass]
public partial class InventoryItemResource : Resource
{
	[Export]
	public string Name {get; set;} = "";
	[Export]
	public Texture2D Texture { get; set; }
}
