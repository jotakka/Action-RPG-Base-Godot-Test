using Godot;

public partial class HeartsContainer : HBoxContainer
{
	[Export]
	public PackedScene? HeartGuiPackedScene;
	public void SetMaxHearts(int maxHealth)
	{
		if(HeartGuiPackedScene is not null)
		{
			for (int i = 0; i < maxHealth; i++)
			{
				AddChild(HeartGuiPackedScene.Instantiate());
			}
		}
	}

	public void UpdateHearts(int currentHealth)
	{
		var heartGuis = GetChildren();
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
