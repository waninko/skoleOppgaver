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
            var shapes = CreateTriangles();
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
        private static Triangle[] CreateTriangles()
        {
            var random = new Random();
            var triangles = new Triangle[1]; 
            for (var i = 0; i < triangles.Length; i++)
            {
                triangles[i] = new Triangle(random, _height);
                triangles[i] = new Triangle(10,10,8);
            }
            return triangles;
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
        private static void Show(Triangle[] triangles)
        {
            Console.Clear();
            for (var row = 0; row < _height; row++)
            {
                for (var col = 0; col < _width; col++)
                {
                    var hasFoundCharacterToPrint = false;
                    foreach (var triangle in triangles)
                    {
                        var character = triangle.GetCharacter(row, col);
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
        private static void Show(Rectangle[] boxes)
        {
            Console.Clear();
            for (var row = 0; row < _height; row++)
            {
                for (var col = 0; col < _width; col++)
                {
                    var hasFoundCharacterToPrint = false;
                    foreach (var box in boxes)
                    {
                        var character = box.GetCharacter(row, col);
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
