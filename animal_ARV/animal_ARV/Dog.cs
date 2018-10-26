using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace animal_ARV
{
    class Dog : Animal
    {
        public bool hasFur = true;
        public bool hasFourLegs = true;
        public void bark()
        {
            Console.WriteLine("WOOF!");
        }
    }
}
