using ARPG.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ARPG.Shared
{
    public sealed class AnimationDirection : TypedStringBase
    {
        public static readonly AnimationDirection Right = new ("right");
        public static readonly AnimationDirection Left = new ("left");
        public static readonly AnimationDirection Up = new ("up");
        public static readonly AnimationDirection Down = new ("down");

        private AnimationDirection(string name) : base(name)
        {
        }
    }
}
