using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace animal_ARV
{
    public class Cat : Animal
    {
        public bool hasFur = true;
        public bool hasFourLegs = true;

        public void meow()
        {
            Console.WriteLine("MEOW!");
        }
    }
}
