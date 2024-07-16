using ARPG.Enemies;
using ARPG.Shared;
using Godot;
using System.Threading.Tasks;

public partial class HitBoxComponent : Area2D
{
	[Export]
	public CollisionShape2D? HitBoxShape;
}
