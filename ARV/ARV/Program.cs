using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ARV
{
    class Program
    {
        private static int _width = 50;
        private static int _height = 20;

        static void Main(string[] args)
        {
            var shapes = CreateShapes();
            while (true)
            {
                Show(shapes);
                foreach (var shape in shapes)
                {
                    shape.Move();
                }
                Thread.Sleep(300);
            }
        }
        private static Shape[] CreateShapes()
        {
            var random = new Random();
            var shapes = new Shape[5]; 
            for (var i = 0; i < shapes.Length; i++)
            {
                if (random.Next(0, 1) == 0)
                    shapes[i] = new Rectangle(random,_width, _height);
                else
                    new Triangle(random, _height);


            }
            return shapes;
        }

        private static Rectangle[] CreateRectangles()
        {
            var random = new Random();
            Rectangle[] boxes = new Rectangle[3];
            for (var i = 0; i < boxes.Length; i++)
            {
                boxes[i] = new Rectangle(random, _width, _height);
            }
            return boxes;
        }


        private static void Show(Shape[] shapes )
        {
            Console.Clear();
            for (var row = 0; row < _height; row++)
            {
                for (var col = 0; col < _width; col++)
                {
                    var hasFoundCharacterToPrint = false;
                    foreach (var shape in shapes)
                    {
                        var character = shape.GetCharacter(row, col);
                        if (character != null)
                        {
                            Console.Write(character);
                            hasFoundCharacterToPrint = true;
                            break;
                        }
                    }
                    if (!hasFoundCharacterToPrint) Console.Write(" ");
                }
                Console.WriteLine();
            }
        }
        
    }
}
