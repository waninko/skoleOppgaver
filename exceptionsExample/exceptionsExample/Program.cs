using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exceptionsExample
{
    class Program
    {
        static void Main(string[] args)
        {
            Person KjellArnt = new Person();

            try
            {
               KjellArnt.fly(); 
            }
            catch(Exception feilmelding)
            {
                Console.WriteLine("Kjell-Arnt er ikke så flink til å fly.  ");
                Console.WriteLine(feilmelding.Message);
                
                //Console.WriteLine("Men han skal ha for at han prøver der han flakser.. " +feilmelding.StackTrace);
            }
        }
    }
}
