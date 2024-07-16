using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ARPG.Util
{
    public abstract class TypedStringBase
    {
        public string Value { get; private set; }

        protected TypedStringBase(string name)
        {
            Value = name;
        }

        public override string ToString()
        {
            return Value;
        }

        public override int GetHashCode()
        {
            return Value.GetHashCode();
        }

        public static implicit operator string(TypedStringBase typedStr)
        {
            return typedStr.Value;
        }
    }
}