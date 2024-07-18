using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Godot;

public partial class EnemyHurtBoxComponent : Area2D
{
	[Export]
	public CollisionShape2D? HurtBoxShape;

	public Vector2 EnemyHitVelocity { get; private set; } = Vector2.Zero;
}

