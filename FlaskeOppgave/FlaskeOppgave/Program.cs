using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace FlaskeOppgave
{
    class Program
    {
        static void Main(string[] args)
        {
            var bottle1 = new Bottle(5);
            var bottle2 = new Bottle(3);
            var wantedVolume = 5;
            var numberOfOperations = 1;

            while (true)
            {
                Console.WriteLine("Prøver med" + numberOfOperations + "operasjoner");
                var operations = new int[numberOfOperations];

                while (true)
                {

                    DoOperations(operations, bottle1, bottle2);
                    if (bottle1.Content == wantedVolume || bottle2.Content == wantedVolume)
                    {
                        Console.WriteLine("Løsningen: ");
                        ShowOperations(operations);
                        Environment.Exit(0);
                    }

                    var success = UpdateOperations(operations);
                    if (!success) break;

                }

                numberOfOperations++;
            }
        }

        private static bool UpdateOperations(int[] operations)
        {
            int i;
            for (i = operations.Length; i >= 0; i--)
            {
                if (operations[i] < 8)
                {
                    operations[i]++;
                    break;
                }

                operations[i] = 0;
            }


            return i != -1;
        }

        private static void ShowOperations(int[] operations)
        {
            foreach (var operation in operations)
            {
                Console.WriteLine(operation);
            }
        }

        private static void DoOperations(int[] operations, Bottle bottle1, Bottle bottle2)
        {
            for (var i = 1; i < operations.Length; i++)
            {
                //køyr på!
                var operation = operations[i];

                if (operation == 0) bottle1.FillUpFromTap(); //Fylle flaske 1

                else if (operation == 1) bottle2.FillUpFromTap(); //Fylle flaske 2

                else if (operation == 2) //tømme fra flaske 1 i flaske 2
                {
                    if (bottle1.IsEmpty()) break;
                    var success = bottle2.Fill(bottle1.Empty());
                    if (!success) break;
                }

                else if (operation == 3) //tømme fra flaske 2 i flaske 1
                {
                    if (bottle2.IsEmpty()) break;
                    var success = bottle2.Fill(bottle2.Empty());
                    if (!success) break;
                }

                else if (operation == 4) //fylle opp flaske 2 med flaske 1
                {
                    var success = bottle2.FillUp(bottle1);
                    if (!success) break;
                }
                else if (operation == 5) //fylle opp flaske 1 med flaske 2
                {
                    var success = bottle1.FillUp(bottle2);
                    if (!success) break;
                }
                else if (operation == 6) //tømme flaske 1
                {
                    bottle1.Empty();
                }
                else if (operation == 7) //tømme flaske 2
                {
                    bottle2.Empty();
                }
            }
        }
    }
}
