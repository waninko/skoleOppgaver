using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ARV
{
    class Triangle
    {

        public int directionX { get; private set; }
        public int directionY { get; private set; }
        public int X { get; private set; }
        public int Y { get; private set; }
        public int Size{ get; private set; }
        private int _minimumSize = 3;

        public Triangle(int x, int y, int size)
        {
            X = x;
            Y = y;
            Size = size;
        }

        public Triangle(Random random, int maxSize)
        {
            directionX = random.Next(0, 2);
            directionY = random.Next(0, 2);
            X = random.Next(0, maxSize - _minimumSize);
            Y = random.Next(0, maxSize - _minimumSize);
            Size = random.Next(_minimumSize, maxSize);

        }

       /* public Triangle(int x, int y, int width, int height)
        {
            X = x;
            Y = y;
            Width = width;
            Height = height;
        }*/

        public string GetCharacter(int row, int col)
        {
            if (row < Y || col < X-1) return null;
            var internalX = col - X;
            var internalY = row - Y;
            if (internalX > 2* Size +2 || internalY > Size + 1) return null; // om man er uttafor sjekker
            if (internalY == Size + 1) return "-";

            var xPositionSlash = Size - internalY;
            var xPositionBackslash = Size + internalY +1;
            if (internalX == xPositionSlash) return "/";
            if (internalX == xPositionBackslash) return "\\";
            return null;
        }

        public void Move()
        {
            X += directionX;
            Y += directionY;
        }

    }
}


