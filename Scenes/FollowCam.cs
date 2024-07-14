using Godot;
using System;

public partial class FollowCam : Camera2D
{
	[Export]
	public TileMap Tilemap;

	public override void _Ready()
	{
		var mapRect = Tilemap.GetUsedRect();
		var tileSize = Tilemap.CellQuadrantSize;
		var worldSizeInPixels = mapRect.Size * tileSize;
		LimitRight = (int)worldSizeInPixels.X;
		LimitBottom = (int)worldSizeInPixels.Y;
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
}
