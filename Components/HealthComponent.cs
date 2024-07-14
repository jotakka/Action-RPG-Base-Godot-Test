using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Godot;

namespace ARPG.Components
{
    public partial class HealthComponent : Node
    {
        [Export]
        public int MaxHealth = 3;

        [Signal]
        public delegate void HealthChangedEventHandler(int newHealth);

        private int _currentHealth;

        public override void _Ready()
        {
            _currentHealth = MaxHealth;
        }

        public void TakeDamage(int damage)
        {
            _currentHealth -= damage;
            EmitSignal(nameof(HealthChanged), _currentHealth);
        }

        public void Heal(int health)
        {
            _currentHealth += health;
            EmitSignal(nameof(HealthChangedEventHandler), _currentHealth);
        }
    }
}
