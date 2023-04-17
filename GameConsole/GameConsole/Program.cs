using System.Diagnostics.CodeAnalysis;

namespace GameConsole
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //   //var player = new PlayerCharacter();
            //   //player.DaysSinceLastLogin = 44;
            //   //int days = player?.DaysSinceLastLogin ?? -1;
            //   //Console.WriteLine($"{days} day(s) since last login");

            //   //PlayerDisplayer.Write(player);

            //   //Console.ReadLine();

            //   PlayerCharacter[] players = new PlayerCharacter[3]
            //   {
            //       new PlayerCharacter {Name = "Sarah"},
            //       new PlayerCharacter(), //Name = null
            //null //PlayerCharacter = null
            //   };

            //   //PlayerCharacter[] players = null;

            //   string p1 = players?[0]?.Name;
            //   string p2 = players?[1]?.Name;
            //   string p3 = players?[2]?.Name;

            //PlayerCharacter p1 = new PlayerCharacter(SpecialDefense.Null);
            //p1.Name = null;
            ////p1.Bio = null;

            //Console.WriteLine("Please enter a bio");
            //string? bio = Console.ReadLine();

            //ExitProgramIfNull(bio, "bio information");
            //p1.Bio = bio;

            //var names = new string[]
            //{
            //    "Sarah",
            //    "Amrit",
            //    "Gentry"
            //};

            //string? FirstNameWithZIn =
            //    FindFirst<string>(names, name => name.Contains("z"));
            //Console.WriteLine(FirstNameWithZIn?.Length);

            //string badParse = "Name-Amrit"; // - instead of :
            //string goodParse = "Name:Amrit";
            //if (PlayerCharacter.TryParse(badParse, out var p1))
            //{
            //    Console.WriteLine(p1.Name);
            //}
            //else
            //{
            //    Console.WriteLine($"could not parse {badParse}");
            //}

            //if (PlayerCharacter.TryParse(goodParse, out var p2))
            //{
            //    Console.WriteLine(p2.Name);
            //}

            //var names = Array.Empty<string>();
            //if (TryGetFirst<string>(names, out var foundName))
            //{
            //    Console.WriteLine(foundName.Length);
            //}
            //else
            //{
            //    Console.WriteLine($"not found {foundName.Length}");
            //}

            ////Console.WriteLine(ConvertToUpperCase(null).Length);
            //Console.WriteLine(ConvertToUpperCase("Sarah").Length);

            Console.WriteLine("Please enter a name");
            string? name = Console.ReadLine();

            if (name == null)
            {
                LogAndExit("null was input");
            }

            Console.WriteLine(name.Length);

            Console.ReadLine();


            //------------------------------------------------------------------------------------------//

            //static void ExitProgramIfNull([NotNull]string? input,  string inputDescription)
            //{
            //    if (input is null)
            //    {
            //        Console.WriteLine($"{inputDescription} was null, exiting program");
            //        Console.ReadLine();
            //        Environment.Exit(-1);
            //    }

            //}

            //[return : MaybeNull]
            //static T FindFirst<T>(IEnumerable<T> items, Func<T, bool> predicate)
            //{
            //    foreach (T item in items)
            //    {
            //        if (predicate(item))
            //        {
            //            return item;
            //        }
            //    }
            //    return default;
            //}

            //static bool TryGetFirst<T>(IEnumerable<T> items,[MaybeNullWhen(false)] out T foundItem)
            //{
            //    if (items.Any())
            //    {
            //        foundItem = items.First();
            //    }

            //    foundItem = default;
            //    return false;
            //}

            //[return : NotNullIfNotNull("s")]
            //static string? ConvertToUpperCase(string? s)
            //{
            //    if (s == null)
            //    {
            //        return null;
            //    }
            //    return s.ToUpperInvariant();
            //}

            [DoesNotReturn]
            static void LogAndExit(string logMessage)
            {
                //Log Message
                Console.WriteLine(logMessage);
                Console.ReadLine();   //pause for Demo Purposes
                Environment.Exit(-1);
            }
            

            PlayerCharacter sarah = new PlayerCharacter(new DiamondSkinDefense())
            {
                Name = "Sarah"
            };
            
            PlayerCharacter amrit = new PlayerCharacter(new IronBonesDefense())
            {
                Name = "Amrit"
            };
            
            PlayerCharacter gentry = new PlayerCharacter (SpecialDefense.Null)
            {
                Name = "Gentry"
            };


            sarah.Hit(10);
            amrit.Hit(10);
            gentry.Hit(10);

           Console.ReadLine();
        }
    }
}