using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameConsole
{
    //public interface ISpecialDefence
    //{
    //    int CalculateDamageReduction();
    //}
    public abstract class SpecialDefence
    {
        public abstract int CalculateDamageReduction();

        public static SpecialDefence Null { get; } = new NullDefence();
        private class NullDefence : SpecialDefence
        {
            public override int CalculateDamageReduction()
            {
                return 0; //"no op and do nothing behavior
            }
        }
    }
}
