
using System;

namespace GameConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            PlayerCharacter Sarah = new PlayerCharacter(new DiamondSkinDefence())
            {
                PlayerName = "Sarah"
            };
            PlayerCharacter Amrit = new PlayerCharacter(new IronBonesDefence())
            {
                PlayerName = "Amrit"
            };
            PlayerCharacter Gentey = new PlayerCharacter( SpecialDefence.Null)
            {
                PlayerName = "Gentey"
            };
            Sarah.Hit(10);
            Amrit.Hit(10);
            Gentey.Hit(10);
            // var player = new PlayerCharacter();
            //PlayerCharacter player = new();

            ////player.PlayerName = "Kavita";
            //player.DaysSinceLastLogin = 42;

            //// PlayerDisplayer.Write(player);
            ////int days = player.DaysSinceLastLogin ?? -1;
            //int days = player?.DaysSinceLastLogin ?? -1;
            ////if(player is null)
            ////{
            ////    days = -1;
            ////}
            ////else
            ////{
            ////    days = player.DaysSinceLastLogin ?? -1;
            ////}
            //Console.WriteLine(days);

            //PlayerCharacter[] players = new PlayerCharacter[]
            //{
            //    new PlayerCharacter{PlayerName="Kavita"},
            //    new PlayerCharacter(), //PlayerName= null;
            //    null //PlayerCharacter =null
            //};

            //PlayerCharacter[] players = null;
            //string p1 = players?[0]?.PlayerName;
            //string p2 = players?[1]?.PlayerName;
            //string p3 = players?[2]?.PlayerName;

            Console.ReadLine();
        }

    }
}

//using Nulls;

//int? i = null;

//string s = null;

//PersonModel P = null;

//PersonModel test1 = new();
//test1.Name = "kavita";

//PersonModel test2 = test1;
//test2.Name = "Kvi";
//test1 = test2;
//Console.WriteLine(test1.Name);
//Console.WriteLine(test2.Name);
