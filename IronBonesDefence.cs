using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameConsole
{
    public class IronBonesDefence : SpecialDefence
    {
        public override int CalculateDamageReduction() => 5;
    }
    //public class IronBonesDefence:ISpecialDefence
    //{
    //    public int CalculateDamageReduction() => 5;
    //}
}
