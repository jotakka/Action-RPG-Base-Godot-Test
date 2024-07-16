using ARPG.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ARPG.Shared
{
    public sealed class EffectType : TypedStringBase
    {
        public static readonly EffectType HurtBlink = new("hurt_blink");
        public static readonly EffectType RESET = new("RESET");

        private EffectType(string name) : base(name)
        {
        }
    }
}
