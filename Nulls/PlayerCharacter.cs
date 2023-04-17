using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameConsole
{
    class PlayerCharacter
    {
        private readonly SpecialDefence _specialDefence;
        public string PlayerName { get; set; }

        public int Health { get; private set; } = 100;

        public PlayerCharacter (SpecialDefence specialDefence)
        {
            _specialDefence = specialDefence;
        }

        public void Hit (int damage)
        {
            //int damageReduction = 0;

            //if (_specialDefence != null)
            //{
               int damageReduction = _specialDefence.CalculateDamageReduction();

            //}
            int totalTotalDamageTaken = Math.Abs(damage - damageReduction);
            Health -= totalTotalDamageTaken;
            Console.WriteLine($"{PlayerName}'s health has been reduced by {totalTotalDamageTaken} to {Health}");
        }
        //public int? DaysSinceLastLogin { get; set; }
        //public DateTime? DateOfBirth { get; set; }

        //public bool? IsNew { get; set; }

        //public PlayerCharacter() {
        //    DateOfBirth = null;
        //    DaysSinceLastLogin = null;
        //}

    }
}
