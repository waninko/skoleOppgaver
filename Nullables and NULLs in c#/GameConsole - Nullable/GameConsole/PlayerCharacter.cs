using System;
using System.Collections.Generic;
using System.Text;

namespace GameConsole
{
    class PlayerCharacter
    {
        public string Name { get; set; }
        public int? DaysSinceLastLogin { get; set; }  //This is a shorter way to write "Nullable<int>"
        public DateTime? DateOfBirth { get; set; } // and "Nullable<DateTime>" 
        public bool? IsNoob { get; set; }

       

    }
}
