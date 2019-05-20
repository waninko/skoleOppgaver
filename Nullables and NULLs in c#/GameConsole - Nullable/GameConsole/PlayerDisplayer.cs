using System;
using System.Collections.Generic;
using System.Text;

namespace GameConsole
{
    class PlayerDisplayer
    {
        public static void Write(PlayerCharacter player)
        {
            if (string.IsNullOrWhiteSpace(player.Name))
            {
                Console.WriteLine("Playername is null or all spaces.");
            }
            else
            {
                Console.WriteLine(player.Name);
            }


            int days = player.DaysSinceLastLogin ?? -1; //--> Method 4

            //int days = player.DaysSinceLastLogin.HasValue ? player.DaysSinceLastLogin.Value : -1; --> Method 3

            //int days = player.DaysSinceLastLogin.GetValueOrDefault(-1); --> Method2
            Console.WriteLine($"{days} days since last login");

            //if (player.DaysSinceLastLogin.HasValue ) --> Method 1 
            //{
            //    Console.WriteLine(player.DaysSinceLastLogin.Value);
                
            //}
            //else
            //{
            //    Console.WriteLine("No value in DaysSinceLastLogin.");
            //}

           
            if (player.DateOfBirth == null)
            {
                Console.WriteLine( "No date of birth specified.");
            }
            else
            {
                Console.WriteLine(  player.DateOfBirth );
            }

            if (player.IsNoob == null)
            {
                Console.WriteLine("Player newbie status is unknown.");
            }
            else if (player.IsNoob == true)
            {
                Console.WriteLine("Player is newbie.");
            }
            else
            {
                Console.WriteLine("Player is experienced.");
            }

        }
    }
}
