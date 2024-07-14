using ARPG.Shared;
using Godot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ARPG.Scenes
{
    internal class ScenesInputController
    {
        public static Vector2 GetNewMovementDirection()
        {
            Vector2 direction = new();
            direction.X = Input.GetActionStrength(UserInput.MoveRight) - Input.GetActionStrength(UserInput.MoveLeft);
            direction.Y = Input.GetActionStrength(UserInput.MoveDown) - Input.GetActionStrength(UserInput.MoveUp);

            // If input is digital, normalize it for diagonal movement
            if (Mathf.Abs(direction.X) == 1 && Mathf.Abs(direction.Y) == 1)
            {
                direction = direction.Normalized();
            }

            return direction;
        }
    }
}
