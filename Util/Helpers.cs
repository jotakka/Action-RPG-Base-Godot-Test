using ARPG.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Godot;

namespace ARPG.Util
{
    public static class Helpers
    {
        public static AnimationDirection GetAnimationDirectionString(Vector2 direction)
        {
            return direction switch
            {
                { X: > 0.0f } => AnimationDirection.Right,
                { X: < 0.0f } => AnimationDirection.Left,
                { Y: < 0.0f } => AnimationDirection.Up,
                { Y: > 0.0f } => AnimationDirection.Down,
                _ => AnimationDirection.Down, // Default to down
            };
        }
    }
}
