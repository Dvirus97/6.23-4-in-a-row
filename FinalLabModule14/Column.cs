using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;

namespace FinalLabModule14
{
    public class Column
    {
        public int ColID { get; private set; }
        //public static int NumberOfColumns { get; set; }
        public int Height { get; private set; }
        public Cell[] Cells { get; private set; }
        public Button Btn { get; private set; }


        public Column(int colID, int height, Grid grd)
        {

            ColID = colID;
            Height = height;
            Cells = new Cell[Height];

            for (int i = 0; i < Height; i++)
            {
                Cell cell = new Cell(i, colID);
                Grid.SetColumn(cell.Elps, colID);
                Grid.SetRow(cell.Elps, Height + 1 - i);
                cell.Elps.Margin = new Thickness(5);
                grd.Children.Add(cell.Elps);
                Cells[i] = cell;
            }



            Btn = new Button();
            Btn.HorizontalAlignment = HorizontalAlignment.Stretch;
            Btn.VerticalAlignment = VerticalAlignment.Stretch;
            Btn.Tapped += Btn_Tapped;
            Btn.Content = "↓";
            Btn.FontSize = 30;
            Grid.SetColumn(Btn, colID);
            Grid.SetRow(Btn, 0);
            grd.Children.Add(Btn);

        }

        //public void DisableGameButton()
        //{
        //    Btn.Tapped -= Btn_Tapped;
        //}
        //public void ActivateGameButton()
        //{
        //    Btn.Tapped += Btn_Tapped;
        //}

        public void Clear()
        {
            for (int i = 0; i < Cells.Length; i++)
            {
                Cells[i].Player = null;
            }
        }

        public bool ColumnFull()
        {
            for (int i = 0; i < Cells.Length; i++)
            {
                if (Cells[i].Player == null)
                {
                    return false;
                }
            }
            Btn.IsEnabled = false;
            return true;
        }

        private void Btn_Tapped(object sender, TappedRoutedEventArgs e)
        {
            Cell theFreeCell = FindFreeCell();
            Player ACT_Player = Board.ActivcePlayer;
            if (theFreeCell != null)
            {
                theFreeCell.Player = ACT_Player;
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
