using ARPG.Shared;
using Godot;

namespace ARPG.Scenes
{
    internal class ScenesInputController
    {
        public static Vector2 GetNewMovementDirection()
        {
            Vector2 direction = new();
            direction.X = Input.GetActionStrength(UserInput.MoveRight.Value) - Input.GetActionStrength(UserInput.MoveLeft.Value);
            direction.Y = Input.GetActionStrength(UserInput.MoveDown.Value) - Input.GetActionStrength(UserInput.MoveUp.Value);

            // If input is digital, normalize it for diagonal movement
            if (Mathf.Abs(direction.X) == 1 && Mathf.Abs(direction.Y) == 1)
            {
                direction = direction.Normalized();
            }

            return direction;
        }
    }
}
