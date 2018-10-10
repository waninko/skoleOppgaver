﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TilfeldigeFirkanter
{
    class Program
    {
        private static int _width = 20;
        private static int _height = 20;

        static void Main(string[] args)
        {
            //var cell = new ScreenCell();
            //cell.AddLowerLeftCorner();
            //cell.AddVertical();

            while (true)
            {
                var boxes = CreateBoxes();
                Show(boxes);
                Console.WriteLine("(press enter for new. ctrl+c=exit)");
                Console.ReadLine();
            }
        }


        private static Box[] CreateBoxes()
        {
            var random = new Random();
            var boxes = new Box[3];
            for (var i = 0; i < boxes.Length; i++)
            {
                boxes[i] = new Box(random, _width, _height);
            }
            return boxes;
        }


        private static void Show(Box[] boxes)
        {
            var screen = new VirtualScreen(_width, _height);

            foreach (var box in boxes)
            {
                screen.Add(box);
            }
                screen.Show();
            //Console.WriteLine(.GetCharacter());
        }
    }
}
