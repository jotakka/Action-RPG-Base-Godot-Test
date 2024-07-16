using Godot;

public partial class HeartsContainer : HBoxContainer
{
	[Export]
	public string HeartGuiScenePath = "res://Scenes/heart_gui.tscn";
	private PackedScene _preloadedScene;

	public override void _Ready()
	{
		_preloadedScene = (PackedScene)ResourceLoader.Load(HeartGuiScenePath);
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

	public void SetMaxHearts(int maxHealth)
	{
		for (int i = 0; i < maxHealth; i++)
		{
			AddChild(_preloadedScene.Instantiate());
			GD.Print("Added HeartGui");
		}
	}

	public void UpdateHearts(int currentHealth)
	{
		var heartGuis = GetChildren();
		GD.PrintS("HeartGuis: " + heartGuis.Count);
		for (int i = 0; i < currentHealth; i++)
		{
			((HeartGui)heartGuis[i]).UpdateHeart(isWhole: true);
		}
		for (int i = currentHealth; i < heartGuis.Count; i++)
		{
			((HeartGui)heartGuis[i]).UpdateHeart(isWhole: false);
		}
	}
}
