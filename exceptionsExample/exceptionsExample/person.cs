using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exceptionsExample
{
    class Person
    {
        public void fly()
        {
           throw new ArgumentException("Han prøvde å fly, og hoppet fra en stol og gikk i bakken. Godt han ikke testa fra taket først."); 
        }
    }
}
