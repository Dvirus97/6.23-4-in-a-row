using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;

namespace FinalLabModule14
{
    internal class Board
    {
        public static Player ActivcePlayer { get; private set; }
        public Column[] Columns { get; set; }
        public Player Player1 { get; set; }
        public Player Player2 { get; set; }
        public int Height { get; set; } = 7;
        public int Width { get; set; } = 7;
        //private int _height = 7;
        //private int _width = 7;

        public Board(Grid grd)
        {
            Columns = new Column[Width];
            for (int i = 0; i < Width; i++)
            {
                Column col = new Column(i, Height, grd);
                col.Btn.Tapped += Btn_Tapped;
                Columns[i] = col;
            
            }
            Player1 = new Player();
            //Player1.Color = new SolidColorBrush(Colors.);
            //Player1.Name = "Red Player";
            Player2 = new Player();
            //Player2.Color = new SolidColorBrush(Colors.Blue);
            //Player2.Name = "Blue Player";
        }

        private void Btn_Tapped(object sender, Windows.UI.Xaml.Input.TappedRoutedEventArgs e)
        {
            SwichActivePlayer();
        }

        private void SwichActivePlayer()
        {
            if (ActivcePlayer == null)
            {
                ActivcePlayer = Player1;
            }
            else
            {
                ActivcePlayer = (ActivcePlayer == Player1) ? Player2 : Player1;
            }
        }

        public void StartGame()
        {
            Clear();
            ActivcePlayer = Player1;
        }

        private void Clear()
        {

        }



    }
}
