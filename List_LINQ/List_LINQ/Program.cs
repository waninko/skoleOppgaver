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
            for (int i = 1; i < regPattern.Clubs.Count; i++)
            {
                var number = i;
                var club = regPattern.Clubs[i];
                Console.WriteLine("Club Number: "+ number + " ||"+  " Club name: " + club.Name);
            }

            Console.WriteLine("Tast inn klubbnummeret du vil slå opp: ");
            var typedNumber = Console.ReadLine(); //dette blir en string visst...
            var convertedNumber = Convert.ToInt32(typedNumber);
            var clubIndex = convertedNumber - 1;
            var selectedClub = regPattern.Clubs[clubIndex];

            Console.WriteLine("Påmeldte i denne klubben: ");
             foreach (var registration in selectedClub.Registrations )
             {
                 Console.WriteLine(registration.MakeString());
             }
        }
    }
}
