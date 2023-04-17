using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace GameConsole
{
    public class DiamondSkinDefence : SpecialDefence
    {
        public override int CalculateDamageReduction() => 1;
    }
    //public class DiamondSkinDefence: ISpecialDefence
    //{
    //    public int CalculateDamageReduction() => 1;  
    //}

}
