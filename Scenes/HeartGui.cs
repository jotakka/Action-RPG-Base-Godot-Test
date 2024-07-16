using Godot;

public partial class HeartGui : Panel
{
	[Export]
	public int FullHeartFrame = 4;
	[Export]
	public int EmptyHeartFrame = 0;

	private Sprite2D _sprite2D;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		_sprite2D = GetNode<Sprite2D>(nameof(Sprite2D));
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

	public void UpdateHeart(bool isWhole)
	{
		_sprite2D.Frame = isWhole ? FullHeartFrame : EmptyHeartFrame;
	}
}
