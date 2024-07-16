using ARPG.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ARPG.Shared
{
    public sealed class AnimationType : TypedStringBase
    {
        public static readonly AnimationType Attack = new ("attack");
        public static readonly AnimationType Idle = new ("idle");
        public static readonly AnimationType Walk = new ("walk");

        private AnimationType(string name) : base(name)
        {
        }
    }
}
