using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Shapes;

namespace FinalLabModule14
{
    public class Board
    {
        public static Player ActivcePlayer { get; private set; }
        public Column[] Columns { get; set; }
        public Player Player1 { get; set; }
        public Player Player2 { get; set; }
        public int Height { get; set; } = 7;
        public int Width { get; set; } = 7;
        public Grid StartGrid { get; set; }
        public Grid MainGrid { get; set; }


        public Board(Grid mainGrid, Grid startGrid)
        {
            MainGrid = mainGrid;
            StartGrid = startGrid;

            Columns = new Column[Width];
            for (int i = 0; i < Width; i++)
            {
                Column col = new Column(i, Height, mainGrid);
                col.Btn.Tapped += Btn_Tapped;
                Columns[i] = col;

            }

            Player1 = new Player();
            //Player1.Color = new SolidColorBrush(Colors.);
            //Player1.Name = "Red Player";
            Player2 = new Player();
            //Player2.Color = new SolidColorBrush(Colors.Blue);
            //Player2.Name = "Blue Player";
            CreatRect();

        }

        void CreatRect()
        {
            Player1.RectanglePlayer = new Rectangle();
            Grid.SetColumn(Player1.RectanglePlayer, 7);
            Grid.SetRow(Player1.RectanglePlayer, 1);
            Grid.SetRowSpan(Player1.RectanglePlayer, 2);
            Grid.SetColumnSpan(Player1.RectanglePlayer, 2);
            Player1.RectanglePlayer.Stroke = new SolidColorBrush(Colors.Yellow);

            Player2.RectanglePlayer = new Rectangle();
            Grid.SetColumn(Player2.RectanglePlayer, 7);
            Grid.SetRow(Player2.RectanglePlayer, 3);
            Grid.SetRowSpan(Player2.RectanglePlayer, 2);
            Grid.SetColumnSpan(Player2.RectanglePlayer, 2);
            Player2.RectanglePlayer.Stroke = new SolidColorBrush(Colors.Yellow);
            
            Player1.RectanglePlayer.Visibility = Player2.RectanglePlayer.Visibility = Visibility.Collapsed;

            MainGrid.Children.Add(Player1.RectanglePlayer);
            MainGrid.Children.Add(Player2.RectanglePlayer);
        }

        private void Btn_Tapped(object sender, Windows.UI.Xaml.Input.TappedRoutedEventArgs e)
        {
            SwichActivePlayer();
            Win();
            BoardFull();
        }

        private void Win()
        {
            TextBlock winTbl = (TextBlock)MainGrid.FindName("winTbl");

            for (int i = 0; i < Width; i++)
            {
                for (int j = 0; j < Height - 3; j++)
                {
                    if (Columns[j].Cells[i].Player == Columns[j + 1].Cells[i].Player &&
                            Columns[j].Cells[i].Player == Columns[j + 2].Cells[i].Player &&
                            Columns[j].Cells[i].Player == Columns[j + 3].Cells[i].Player &&
                            Columns[j].Cells[i].Player != null)
                    {
                        winTbl.Text = Columns[j].Cells[i].Player.Name + " Win";
                        DisableGameButton();
                       
                    }
                }
            }
            for (int i = 0; i < Width; i++)
            {
                for (int j = 0; j < Height-3; j++)
                {
                    if (Columns[i].Cells[j].Player == Columns[i].Cells[j + 1].Player &&
                           Columns[i].Cells[j].Player == Columns[i].Cells[j + 2].Player &&
                           Columns[i].Cells[j].Player == Columns[i].Cells[j + 3].Player &&
                           Columns[i].Cells[j].Player != null)
                    {
                        winTbl.Text = Columns[i].Cells[j].Player.Name + " Win";
                        DisableGameButton();
                       

                    }
                }
            }
            for (int i = 0; i < Width-3; i++)
            {
                for (int j = 0; j < Height - 3; j++)
                {
                    if (Columns[i].Cells[j].Player == Columns[i + 1].Cells[j + 1].Player &&
                          Columns[i].Cells[j].Player == Columns[i + 2].Cells[j + 2].Player &&
                          Columns[i].Cells[j].Player == Columns[i + 3].Cells[j + 3].Player &&
                          Columns[i].Cells[j].Player != null)
                    {
                        winTbl.Text = Columns[i].Cells[j].Player.Name + " Win";
                        DisableGameButton();
                       

                    }
                }
            }
            for (int i = 0; i < Width-3; i++)
            {
                for (int j = 0; j < Height - 3; j++)
                {
                    if (Columns[i].Cells[j + 3].Player == Columns[i + 1].Cells[j + 2].Player &&
                          Columns[i].Cells[j + 3].Player == Columns[i + 2].Cells[j + 1].Player &&
                          Columns[i].Cells[j + 3].Player == Columns[i + 3].Cells[j].Player &&
                          Columns[i].Cells[j + 3].Player != null)
                    {
                        winTbl.Text = Columns[i].Cells[j + 3].Player.Name + " Win";
                        DisableGameButton();
                       

                    }
                }
            }
        }

        private void DisableGameButton()
        {
            //for (int k = 0; k < Columns.Length; k++)
            //{
            //    Columns[k].DisableGameButton();
            //    Columns[k].Btn.Tapped -= Btn_Tapped;
            //}
            for (int i = 0; i < Columns.Length; i++)
            {
                Columns[i].Btn.IsEnabled = false;
            }
        }

        void BoardFull()
        {
            TextBlock winTbl = (TextBlock)MainGrid.FindName("winTbl");
            int count = 0;
            for (int i = 0; i < Columns.Length; i++)
            {
                if (Columns[i].ColumnFull())
                {
                    count++;
                }
            }
            if (count == Width)
            {
                winTbl.Text = "Tie. no win";
            }
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
                Player1.RectanglePlayer.Visibility = Player2.RectanglePlayer.Visibility = Visibility.Collapsed;
                ActivcePlayer.RectanglePlayer.Visibility = Visibility.Visible;
            }
        }

        public void StartGame()
        {
            //DisableGameButton();
            Clear();
            ActivcePlayer = Player1;
            Player1.RectanglePlayer.Visibility = Player2.RectanglePlayer.Visibility = Visibility.Collapsed;
            ActivcePlayer.RectanglePlayer.Visibility = Visibility.Visible;
            //for (int i = 0; i < Columns.Length; i++)
            //{
            //    Columns[i].ActivateGameButton();
            //    Columns[i].Btn.Tapped += Btn_Tapped;
            //}

        }

        public void Clear()
        {
            for (int i = 0; i < Columns.Length; i++)
            {
                Columns[i].Clear();
            }
            for (int i = 0; i < Columns.Length; i++)
            {
                Columns[i].Btn.IsEnabled = true;
            }
            TextBlock winTbl = (TextBlock)MainGrid.FindName("winTbl");
            winTbl.Text = "";
        }



    }
}
