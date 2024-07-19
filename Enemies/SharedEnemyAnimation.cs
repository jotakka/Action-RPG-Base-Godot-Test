using ARPG.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ARPG.Enemies
{
    public sealed class SharedEnemyAnimation : TypedStringBase
    {
        public static readonly SharedEnemyAnimation Death = new("death");

        private SharedEnemyAnimation(string name) : base(name)
        {
        }
    }
}
