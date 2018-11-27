using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace LINQextensionMethods
{
    class Program
    {
        static void Main()
        {   
            //stor bokstav først og resten smått - fra en referert class
            string s = "TeSt StrING";
            var s2 = s.ToFirstUpperRestLower();

            Console.WriteLine("Testing refered classes; letter sizing.");
            Console.WriteLine(s);
            Console.WriteLine(s2);
            Console.WriteLine("Testing with yield return, primes and their quads; ");
            YieldReturn();



        }
        //Yields return demo
        private static void YieldReturn()
        {
            var start = DateTime.Now;
            //var primes = GetPrimes(1000);
            /*with yield*/ //GetPrimes2().Take(5000).Count();
           // var primes =
           GetPrimes2()
                .Take(10)
                .Select(Square)
                .Count();
            var timeSpan = DateTime.Now.Subtract(start);
            Console.WriteLine("Calculation time in MS: " + timeSpan.TotalMilliseconds.ToString("N"));
            /*
             foreach (var prime in primes)
             {
                 Console.Write(prime);
                 Console.Write(" ");
             }*/

        }

        private static int Square(int arg)
        {
            var square = arg * arg;
            Console.WriteLine($"Kvadrat: {arg}*{arg} = {square}"  );
            return square;
        }

        private static IEnumerable<int> GetPrimes(int wantedCount)
        {
            var primes = new int[wantedCount];
            var count = 0;
            var currentNumber = 2;
            while (count < wantedCount)
            {
                var foundNumber = Enumerable
                    .Range(2, currentNumber - 2)
                    .Any(n => currentNumber % n == 0);

                if (!foundNumber)
                {
                    primes[count] = currentNumber;
                    count++;

                }
                currentNumber++;
            }

            return primes;

        }


        private static IEnumerable<int> GetPrimes2()
        {

            for (var currentNumber = 2; true; currentNumber++)
            {
                var isPrime = Enumerable
                    .Range(2, currentNumber - 2)
                    .Any(n => currentNumber % n == 0);
                if (isPrime) yield return currentNumber;
               
            }

        }


    }
}
