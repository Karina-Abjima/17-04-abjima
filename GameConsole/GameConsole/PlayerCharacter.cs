using System.CodeDom.Compiler;
using System.Diagnostics.CodeAnalysis;

namespace GameConsole
{
    class PlayerCharacter
    {
        private string  _name = GenerateName();
        [AllowNull]
        public string Name
        {
            get => _name;
            set => _name = value ?? GenerateName();
        }

        private string? _bio;

        [DisallowNull]
        public string? Bio
        {
            get => _bio;
            set => _bio = value ?? throw new ArgumentNullException(nameof(value));
        }

        public int? DaysSinceLastLogin { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public bool? IsNoob { get; set; }

        public static bool TryParse(string input,[NotNullWhen(true)] out PlayerCharacter? player)
        {
            //simple implementation like "Name : xyz"
            if (string.IsNullOrWhiteSpace(input))
            {
                player = null;
                return false;
            }
            if (!input.StartsWith("Name:"))
            {
                player = null;
                return false;
            }

            //Additional validation code

            string parsedName = input.Split(':')[1];
            player = new PlayerCharacter(SpecialDefense.Null) { Name = parsedName };
            return true;
        }

            private static string GenerateName()
        {
            var names = new string[] { "Amrit", "Gentry", "Sarah" };

            var random = new Random();

            return names[random.Next(0, 3)];
        }

        private readonly SpecialDefense _specialDefence;
        public int Health { get; private set; } = 100;

        public PlayerCharacter( SpecialDefense specialDefense)
        {
            _specialDefence = specialDefense;
        }

        public void Hit (int damage)
        {

            //if (_specialDefence != null)
            //{
                int damageReduction = _specialDefence.CalculateDamageReduction();
            //}

            int totalDamageTaken = Math.Abs(damage - damageReduction);

            Health -= totalDamageTaken;

            Console.WriteLine($"{Name}'s health has been reduced by {totalDamageTaken} to {Health}.");
        }

    }
}
