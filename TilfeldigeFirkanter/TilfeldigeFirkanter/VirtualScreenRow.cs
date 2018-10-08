using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TilfeldigeFirkanter
{
    class VirtualScreenRow
    {
        private ScreenCell[] _cells;

        public VirtualScreenRow(int width)
        {
            _cells = new ScreenCell[width];
            for (var i = 0; i < _cells.Length; i++)
            {
                _cells[i] = new ScreenCell();
            }
        }


        public void AddTopRow(int startX, int width)
        {
            var endX = startX + width;
            _cells[startX].AddUpperLeftCorner();
            _cells[endX].AddUpperRightCorner();
            for (var colId = startX + 1; colId < endX; colId++)
            {
                _cells[colId].AddHorizontal();
            }
        }


        public void AddBottomRow(int startX, int width)
        {
            var endX = startX + width;
            _cells[startX].AddLowerLeftCorner();
            _cells[endX].AddLowerRightCorner();
            for (var colId = startX + 1; colId < endX; colId++)
            {
                _cells[colId].AddHorizontal();
            }
        }


        public void AddMiddleRow(int startX, int width)
        {
            _cells[startX].AddVertical();
            _cells[startX + width].AddVertical();
        }


        public void Show()
        {
            var array = _cells.Select(c => c.GetCharacter()).ToArray();
            Console.WriteLine(array);
        }
    }


}

