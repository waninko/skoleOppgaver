using System;

namespace GameConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            var player = new PlayerCharacter();
            player.Name = "Testname";
            player.DaysSinceLastLogin = 73;


            PlayerDisplayer.Write(player);

            Console.ReadLine();
        }
    }
}
