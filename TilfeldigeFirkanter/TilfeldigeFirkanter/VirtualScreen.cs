using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TilfeldigeFirkanter
{
    class VirtualScreen
    {
        private VirtualScreenRow[] _rows;

        public VirtualScreen(int width, int height)
        {
            _rows = new VirtualScreenRow[height];
            for (var i = 0; i < _rows.Length; i++)
            {
                _rows[i] = new VirtualScreenRow(width);
            }
        }

        public void Add(Box box)
        {
            var firstY = box.GetTopRowY();
            var lastY = box.GetBottomRowY();
            _rows[firstY].AddTopRow(box.X, box.Width);
            _rows[lastY].AddBottomRow(box.X, box.Width);

            for (var rowId = firstY + 1; rowId < lastY; rowId++)
            {
                _rows[rowId].AddMiddleRow(box.X, box.Width);
            }
        }

        public void Show()
        {
            Console.Clear();
            foreach (var row in _rows)
            {
                row.Show();
            }
        }
    }
}
