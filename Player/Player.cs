using ARPG.Enemies;
using ARPG.Player;
using ARPG.Shared;
using Godot;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

public static class Animations { 
	public const string IdleDown = "idle_down";
	public const string HurtBlink = "heart_blink";
	public const string Reset = "RESET";
}

public partial class Player : CharacterBody2D
{
	[Export]
	public string DefaultAnimation = Animations.IdleDown;
	[Export]
	public float DefaultSpeed = 2.0f;
	[Export]
	public int MaxHealth = 3;
	[Export]
	public int KnockBackFactor = 200;
	[Export]
	public string EffectsPlayerNode = "Effects";
	[Export]
	public string HurtTimerNode = "HurtTimer";
	[Export]
	public string HurtBoxNode = "HurtBox";
	[Export]
	public InventoryResource InventoryResource;

	[Signal]
	public delegate void HealthChangedEventHandler(int newHealth);

	private int _currentHealth;


	private CharacterAnimationController _animationController;
	private AnimationPlayer _effectsPlayer;
	private Area2D _hurtBox;

	private Timer _hurtTimer;
	private bool _isHurt = false;


	private Vector2 _newDirection = new Vector2(0, 1);
	public override void _Ready()
	{
		_effectsPlayer = GetNode<AnimationPlayer>(EffectsPlayerNode);
		_animationController = new(
			GetNode<AnimatedSprite2D>(nameof(AnimatedSprite2D)),
			GetNode<AnimationPlayer>(nameof(AnimationPlayer))
		);
		
		_hurtTimer = GetNode<Timer>(HurtTimerNode);
		_hurtBox = GetNode<Area2D>(HurtBoxNode);

		_currentHealth = MaxHealth;
		_hurtTimer.Timeout += ResetHurtState;
		_effectsPlayer.Play(Animations.Reset);

	}

	public override void _PhysicsProcess(double delta)
	{
		Vector2 movementDirection = PlayerInputProcessor.GetNewMovementDirection();
		Velocity = movementDirection * DefaultSpeed;

		MoveAndCollide(Velocity);

		if(Input.IsActionJustPressed(UserInput.Attack))
		{
			_animationController.SetAttackAnimation(movementDirection);
			GD.Print("Walk Animation");
		}
		else
		{
			_animationController.SetWalkAnimation(movementDirection);
		}

		if (_isHurt is false)
		{
			foreach( var collisionArea in _hurtBox.GetOverlappingAreas())
			{
				if(collisionArea.Name == EnemyConsts.HitBoxName)
				{
					HurtByEnemy(collisionArea);
				}
			}
		}
	}

	private async void OnHitBoxEnteredAsync(Area2D area)
	{
		if (area is CollectableBase collectable)
		{
			await collectable.OnCollectedAsync(InventoryResource);
		}
	}

	public void AddHealth(int health)
	{
		_currentHealth = Mathf.Min(_currentHealth + health, MaxHealth);
		EmitSignal(nameof(HealthChanged), _currentHealth);
	}
	private async void HurtByEnemy(Area2D enemyArea)
	{
		_isHurt = true;
		_currentHealth = _currentHealth == 0 ? MaxHealth : _currentHealth - 1;
		GD.PrintS("Player Health: " + _currentHealth);
		EmitSignal(nameof(HealthChanged), _currentHealth);
		KnockBack(enemyArea.GetParent<CharacterBody2D>().Velocity);
		await HurtAnimationAsync();
	}

	private async Task HurtAnimationAsync()
	{         
		_effectsPlayer.Play(Animations.HurtBlink);
		_hurtTimer.Start();
		GD.Print("Hurt Animation");
	}

	private void ResetHurtState()
	{
		_effectsPlayer.Play(Animations.Reset);
		_isHurt = false;
	}

	private void KnockBack(Vector2 enemyVelocity)
	{
		Velocity = (enemyVelocity - Velocity)* KnockBackFactor;
		MoveAndSlide();
	}
}

