using ARPG.Enemies;
using ARPG.Player;
using ARPG.Shared;
using Godot;
using System.Threading.Tasks;

public partial class PlayerNode : CharacterBody2D
{
	[Export]
	public PlayerInputProcessor? PlayerInputProcessor { get; set; }
	[Export]
	public WalkAnimationComponent? WalkAnimationComponent { get; set; }
	[Export]
	public AttackComponent? AttackComponent { get; set; }
	[Export]
	public HurtBoxComponent? HurtBoxComponent { get; set; }
	[Export]
	public WeaponComponent? WeaponComponent { get; set; }
	[Export]
	public CollisionObject2D? CollisionBox { get; set; }
	[Export]
	public HealthComponent? HealthComponent { get; set; }
	[Export]
	public Sprite2D? Sprite2D { get; set; }
	[Export]
	public float DefaultSpeed { get; set; } = 2.0f;
	[Export]
	public int KnockBackFactor { get; set; } = 10;
	[Export]
	public InventoryResource? InventoryResource;
	public PlayerStateMachine StateMachine { get; private set; } = null!;
	public override void _Ready()
	{
		StateMachine = new PlayerStateMachine(this);

		if(HurtBoxComponent is not null)
		{
			HurtBoxComponent.HurtByEnemySignal += OnHurt;
		}
	}

	public override void _PhysicsProcess(double delta)
	{
		StateMachine.Update(delta);
	}

	private void OnHurt()
	{
		StateMachine.ChangeState(PlayerInputAction.Hurt);
	}
}

