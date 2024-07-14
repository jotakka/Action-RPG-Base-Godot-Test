using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Godot;

namespace ARPG.Components
{
    public partial class AttackComponent : Node
    {
        [Export]
        public int Damage = 1;

        public void DealDamage(Node target)
        {
            if (target is HealthComponent healthComponent)
            {
                healthComponent.TakeDamage(Damage);
            }
        }

    }
}
