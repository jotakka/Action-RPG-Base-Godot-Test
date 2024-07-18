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
	public HitBoxComponent? HitBoxComponent { get; set; }
	[Export]
	public WeaponBase? Weapon { get; set; }
	[Export]
	public CollisionObject2D? CollisionBox { get; set; }
	[Export]
	public HealthComponent? HealthComponent { get; set; }
	[Export]
	public Sprite2D? Sprite2D { get; set; }
	[Export]
	public InventoryResource? InventoryResource{ get; set; }
	[Export]
	public CollectingComponent? CollectingComponent { get; set; }
	[Export]
	public float DefaultSpeed { get; set; } = 2.0f;
	[Export]
	public int KnockBackFactor { get; set; } = 10;
	public PlayerStateMachine StateMachine { get; private set; } = null!;
	public override void _Ready()
	{
		StateMachine = new PlayerStateMachine(this);

		if(HitBoxComponent is not null)
		{
			HitBoxComponent.HurtByEnemySignal += OnHurt;
		}

		if(CollectingComponent is not null)
		{
			CollectingComponent.ItemCollectedSignal += InventoryResource!.AddItem;
		}

		Weapon!.HideWeapon();
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

