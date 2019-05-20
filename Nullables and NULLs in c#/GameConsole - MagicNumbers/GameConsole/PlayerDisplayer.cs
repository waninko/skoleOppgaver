using System;
using System.Collections.Generic;
using System.Text;

namespace GameConsole
{
    class PlayerDisplayer
    {
        public static void Write(PlayerCharacter player)
        {
            Console.WriteLine(player.Name);

            //if the player has never logged in - we need to display DaysSinceLastLogin as null.
            //as an int - it' cannot be displayed as null - so we have to use what's called a "magic number" approach.
            // --choosing a number to represent the NULL value

            if (player.DaysSinceLastLogin == -1)
            {
                Console.WriteLine("No value in DaysSinceLastLogin ");
            }
            else
            {
                Console.WriteLine( player.DaysSinceLastLogin );
            }

            //the same goes for the DateTime class - not nullable, so we'll have to work around it
            //DateTime.MinValue is a built-in constant wich represents the "smallest" value that can be represented.
            if (player.DateOfBirth == DateTime.MinValue)
            {
                Console.WriteLine( "No date of birth specified");
            }
            else
            {
                Console.WriteLine(  player.DateOfBirth );
            }

        }
    }
}
