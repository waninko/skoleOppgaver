using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace calculator
{
    class Program
    {
        static void Main(string[] args)
        {
            int firstNumber;
            int secondNumber;
            string whatToDo;
            int result;
            var validNumbers = new[] {1,2,3,4,5,6,7,8,9};
            var validOperations = new[] {"+", "-" };
            //bool rightOperator = whatToDo.Contains(validOperations);


            for (int i = 5; i > 0; i--)
            {
                Console.WriteLine(i);

            }

            Console.WriteLine("hei&Hå! Her er en + og - kalkulator!");
            Console.WriteLine("Skriv inn ditt første tall: ");
            firstNumber = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Skriv inn ditt andre tall: ");
            secondNumber = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("skriv - eller + ");
            whatToDo = Console.ReadLine();

            if (whatToDo == "+")
            {
                result = firstNumber + secondNumber;
                Console.WriteLine(firstNumber + " + " + secondNumber + " = " + result);

            }
            else if (whatToDo == "-")
            {
                result = firstNumber - secondNumber;
                Console.WriteLine(firstNumber + " - " + secondNumber + " = " + result);
            }

            else {
                Console.WriteLine("Bare skriv + eller - som operasjon er du snill.");
                Console.ReadLine();
            }
        }
    }
}
