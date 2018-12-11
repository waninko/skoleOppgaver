using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using TrePåRad_WPF.Model;

namespace TrePåRad_WPF.View
{
    class CellView : Button
    {
        public CellModel CellModel { get; set; }

        public CellView()
        {
            Height= 75;
            Width=75;
            FontSize = 48;
            HorizontalAlignment = HorizontalAlignment.Left;
            VerticalAlignment = VerticalAlignment.Top;
        }

        public void Update()
        {
            Content = CellModel.IsEmpty() ? string.Empty
                : CellModel.IsPlayer1() ? "x" : "o";
        }
    }
}
