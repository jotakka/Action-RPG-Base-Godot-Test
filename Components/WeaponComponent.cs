using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Godot;

public partial class WeaponComponent : Node2D
{
	[Export]
	public WeaponBase? Weapon { get; set; }

	public override void _Ready()
	{
		Weapon?.Hide();
	}

	public void ShowWeapon()
	{
		Weapon?.Show();
	}
	public void HideWeapon()
	{
		Weapon?.Hide();
	}
}

