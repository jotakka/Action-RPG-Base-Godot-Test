using Godot;

public sealed partial class WeaponBase : Area2D
{
	[Export]
	public Sprite2D Sprite2D { get; set; } = null!;
	[Export]
	public CollisionShape2D CollisionShape { get; set; } = null!;
	[Export]
	public int Damage { get; set; } = 1;

	public void ShowWeapon()
	{
		SetColision(true);
		Sprite2D.Show();
	}
	public void HideWeapon()
	{
		SetColision(false);
		Sprite2D.Hide();
	}

	private void SetColision(bool value)
	{
		this.SetCollisionLayerValue(
			(int)CollisionLayerNumber.HurtBox,
			value
		);
	}

}

