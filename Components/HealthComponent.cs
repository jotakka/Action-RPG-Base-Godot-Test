using Godot;
using System;

public partial class HealthComponent : Node
{
	[Export]
	public int MaxHealth { get; set; } = 3;
	[Signal]
	public delegate void HealthChangedSignalEventHandler(int newHealth);

	private int _currentHealth;

	public override void _Ready()
	{
		_currentHealth = MaxHealth;
	}

	public void TakeDamage(int damage = 1)
	{
		_currentHealth -= damage;
		_currentHealth = _currentHealth < 0 ? MaxHealth : _currentHealth;
		EmitSignal(nameof(HealthChangedSignal), _currentHealth);
	}

	public void Heal(int health = 1)
	{
		_currentHealth = Math.Min(MaxHealth, health + _currentHealth);
		EmitSignal(nameof(HealthChangedSignal), _currentHealth);
	}
}
