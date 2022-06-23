using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;

namespace FinalLabModule14
{
    public class Column
    {
        public int ColNum { get; private set; }
        public int Height { get; private set; }
        public Cell[] Cells { get; private set; }
        public Button Btn { get; private set; }

        public Column(int colNum, int height, Grid grd)
        {
            ColNum = colNum;
            Height = height;
            Cells = new Cell[Height];
            for (int i = 0; i < Height; i++)
            {
                Cell cell = new Cell(i, colNum);
                Grid.SetColumn(cell.Elps, colNum);
                Grid.SetRow(cell.Elps, Height + 1 - i);
                grd.Children.Add(cell.Elps);
                Cells[i] = cell;
            }

            Btn = new Button();
            Btn.HorizontalAlignment = HorizontalAlignment.Stretch;
            Btn.VerticalAlignment = VerticalAlignment.Stretch;
            Btn.Tapped += Btn_Tapped;
            Grid.SetColumn(Btn, colNum);
            Grid.SetRow(Btn, 0);
            grd.Children.Add(Btn);

        }

        private void Btn_Tapped(object sender, TappedRoutedEventArgs e)
        {
            Player player = Board.ActivcePlayer;
            Cell cell = FindFreeCell();
            if(cell != null)
            {
                cell.Player = player;
            }

        }

        private Cell FindFreeCell()
        {
            for (int i = 0; i < Height; i++)
            {
                if (Cells[i].Player == null)
                {
                    return Cells[i];
                }
            }
            return null;
        }
    }
}
