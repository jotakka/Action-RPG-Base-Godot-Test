using ARPG.Enemies;
using ARPG.Player;
using ARPG.Shared;
using Godot;
using System.Threading.Tasks;

public partial class PlayerNode : CharacterBody2D
{
	[Export]
	public PlayerInputProcessor? PlayerInputProcessor;
	[Export]
	public WalkAnimationComponent? WalkAnimationComponent;
	[Export]
	public AttackComponent? AttackComponent;
	[Export]
	public HurtBoxComponent? HurtBoxComponent;
	[Export]
	public WeaponComponent? WeaponComponent;
	[Export]
	public HitBoxComponent? HitBoxComponent;
	[Export]
	public Sprite2D? Sprite2D;

	public PlayerStateMachine StateMachine { get; private set; } = null!;

	[Export]
	public float DefaultSpeed = 2.0f;
	[Export]
	public int MaxHealth = 3;
	[Export]
	public int KnockBackFactor = 10;
	[Export]
	public InventoryResource InventoryResource;

	[Signal]
	public delegate void HealthChangedEventHandler(int newHealth);

	private int _currentHealth;
	private bool _isHurt = false;


	private Vector2 _newDirection = new Vector2(0, 1);
	public override void _Ready()
	{
		StateMachine = new PlayerStateMachine(this);
		_currentHealth = MaxHealth; 

		if(HurtBoxComponent is not null)
		{
			HurtBoxComponent.HurtByEnemySignal += OnHurt;
		}
	}

	public override void _PhysicsProcess(double delta)
	{
		StateMachine.Update(delta);
	}

	//private async void OnHitBoxEnteredAsync(Area2D area)
	//{
	//	if (area is CollectableBase collectable)
	//	{
	//		await collectable.OnCollectedAsync(InventoryResource);
	//	}
	//}

	private void OnHurt()
	{
		StateMachine.ChangeState(PlayerInputAction.Hurt);
	}
}

