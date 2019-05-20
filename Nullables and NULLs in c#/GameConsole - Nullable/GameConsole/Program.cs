using System;

namespace GameConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            PlayerCharacter player = new PlayerCharacter();
            player.DaysSinceLastLogin = 73;

            int days = player?.DaysSinceLastLogin ?? -1;


            Console.WriteLine(days);

            Console.ReadLine();



            ///USE THIS///
            //PlayerCharacter[] players = new PlayerCharacter[3]
            //{
            //    new PlayerCharacter {  Name = "TestName"},
            //    new PlayerCharacter(), // Name = null
            //    null // PlayerCharacter = null
            //};

            ///OR THIS - not both - to check for NULL values///
            //PlayerCharacter[] players = null; 

            //string p1 = players?[0]?.Name;
            //string p2 = players?[1]?.Name;
            //string p3 = players?[2]?.Name;

            //Console.ReadLine();
        }
    }
}
