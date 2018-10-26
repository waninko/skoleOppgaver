using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace animal_ARV
{
    class Bird : Animal
    {
        public bool hasFeathers = true;
        public bool canFly = true;

        public void sing()
        {
            Console.Beep();
            Console.WriteLine("TWEET!");
        }

        
    }
}
