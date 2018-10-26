using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace animal_ARV
{
    class Program
    {
        static void Main(string[] args)
        {
            Cat testCat = new Cat();
            Dog testDog = new Dog();
            Bird testBird = new Bird();

            testCat.meow();
            testDog.bark();
            testBird.sing();
            
        }
    }
}
