using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace List_LINQ
{
    class Program
    {
        static void Main(string[] args)
        {
            /*var startlistPath = File.ReadAllText(@"C:\Users\Bird\source\repos\List_LINQ\List_LINQ\startlist.csv");
            string[] lines = File.ReadAllLines(@"C: \Users\Bird\source\repos\List_LINQ\List_LINQ\startlist.csv");
            string[] words = startlistPath.Split(',');
            Console.WriteLine("Contents of WriteLines2.txt = ");
            foreach (string line in lines)
            {
                // Use a tab to indent each line of the file.
                //Console.WriteLine("\t" + line);
            }

            Console.WriteLine(words[2]);*/

            var regPattern = new RegistrationPattern();

            using (var file = new StreamReader("startlist.csv"))
            {
                var line =  file.ReadLine();
                while ((line=file.ReadLine()) != null)
                {
                    regPattern.lineHandler(line);
                    //line = file.ReadLine();
                }
            }

            Console.WriteLine("Klubber: ");
            foreach (var club in regPattern.Clubs)
            {
                Console.WriteLine(club.Name);
            }
        }
    }
}
