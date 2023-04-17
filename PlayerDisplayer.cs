//using System;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace GameConsole
//{
//    static class PlayerDisplayer
//    {
//        public static void Write(PlayerCharacter player)
//        {
//            if (string.IsNullOrEmpty(player.PlayerName))
//            {
//                Console.WriteLine("Player name is Empty, Null or all Whitespaces");
//            }
//            else 
//            {
//                Console.WriteLine(player.PlayerName);
//            }
//            //int days = player.DaysSinceLastLogin.GetValueOrDefault(-1);
//            // int days = player.DaysSinceLastLogin.HasValue ? player.DaysSinceLastLogin.Value : -1;
//            int days = player.DaysSinceLastLogin ?? -1;
//            Console.WriteLine($"{days} since last Login");

//            //if (player.DaysSinceLastLogin.HasValue)
//            //{
//            //    Console.WriteLine(player.DaysSinceLastLogin);
                
//            //}
//            //else
//            //{
//            //    Console.WriteLine("No values for DaySinceLastLogin");
//            //}
//            if (player.DateOfBirth is null)
//            {
//                Console.WriteLine("No date of birth specified");
//            }
//            else
//            {
//                Console.WriteLine(player.DateOfBirth);
//            }
//            if (player.IsNew == null)
//            {
//                Console.WriteLine("Player new status is Unknown");
//            }
//            else if (player.IsNew == true)
//            {
//                Console.WriteLine("player is new to the game");
//            }
//            else
//            {
//                Console.WriteLine("Player is Experinced");
//            }
//        }
//    }
//}
