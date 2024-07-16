using Godot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Godot;

public sealed partial class WeaponBase : Area2D
{
	[Export]
	public Sprite2D? Sprite2D { get; set; }
	[Export]
	public CollisionShape2D? CollisionShape2D { get; set; }
	[Export]
	public int Damage { get; set; } = 1;

	public void ShowWeapon()
	{
		Sprite2D?.Show();
	}
	public void HideWeapon()
	{
		Sprite2D?.Hide();
	}

}

