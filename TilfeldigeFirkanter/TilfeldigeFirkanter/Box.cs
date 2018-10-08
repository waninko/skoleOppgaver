using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TilfeldigeFirkanter
{
   public class Box
    {
        public int X { get; private set; }
        public int Y { get; private set; }
        public int Width { get; private set; }
        public int Height { get; private set; }
        private int _minimumSize = 3;

        public Box(Random random, int maxX, int maxY)
        {
            X = random.Next(0, maxX - _minimumSize);
            Y = random.Next(1, maxY - _minimumSize); ;
            Width = random.Next(_minimumSize, maxX - X); ;
            Height = random.Next(_minimumSize, maxY - Y);
        }

        public Box(int x, int y, int width, int height)
        {
            X = x;
            Y = y;
            Width = width;
            Height = height;
        }

        
        public int GetTopRowY()
        {
            return Y;
        }

        public int GetBottomRowY()
        {
            return Y + Height;
        }



    }

}

