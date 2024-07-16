using Godot;

public partial class HeartGui : Panel
{
	[Export]
	public Sprite2D? Sprite2D { get; set; }
	[Export]
	public int FullHeartFrame { get; set; } = 4;
	[Export]
	public int EmptyHeartFrame { get; set; } = 0;

	public override void _Ready()
	{
		if(Sprite2D is not null)
		{
			Sprite2D.Frame = FullHeartFrame;
		}
	}
	
	public void UpdateHeart(bool isWhole)
	{
		if(Sprite2D is not null)
		{
			Sprite2D.Frame = isWhole ? FullHeartFrame : EmptyHeartFrame;
		}
	}
}
