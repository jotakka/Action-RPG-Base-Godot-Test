using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Godot;

namespace ARPG.Components
{
    public partial class HurtBoxComponent : Node2D
    {
        [Export]
        public CollisionShape2D? _collisionShape2D;
    }
}
