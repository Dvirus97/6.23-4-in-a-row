using System;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

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
            Grid.SetColumn(Player1.RectanglePlayer, 7);
            Grid.SetRow(Player1.RectanglePlayer, 1);

            Grid.SetColumn(Player2.RectanglePlayer, 7);
            Grid.SetRow(Player2.RectanglePlayer, 3);

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
            for (int i = 0; i < Width - 3; i++)
            {
                for (int j = 0; j < Height; j++)
                {
                    if (Columns[i].Cells[j].Player == Columns[i + 1].Cells[j].Player &&
                        Columns[i].Cells[j].Player == Columns[i + 2].Cells[j].Player &&
                        Columns[i].Cells[j].Player == Columns[i + 3].Cells[j].Player &&
                        Columns[i].Cells[j].Player != null)
                    {
                        DisableGameButton(Columns[i].Cells[j].Player.Name);
                        return;
                    }
                }
                for (int j = 0; j < Height - 3; j++)
                {
                    if (Columns[i].Cells[j].Player == Columns[i + 1].Cells[j + 1].Player &&
                        Columns[i].Cells[j].Player == Columns[i + 2].Cells[j + 2].Player &&
                        Columns[i].Cells[j].Player == Columns[i + 3].Cells[j + 3].Player &&
                        Columns[i].Cells[j].Player != null)
                    {
                        DisableGameButton(Columns[i].Cells[j].Player.Name);
                        return;
                    }
                    if (Columns[i].Cells[j + 3].Player == Columns[i + 1].Cells[j + 2].Player &&
                       Columns[i].Cells[j + 3].Player == Columns[i + 2].Cells[j + 1].Player &&
                       Columns[i].Cells[j + 3].Player == Columns[i + 3].Cells[j].Player &&
                       Columns[i].Cells[j + 3].Player != null)
                    {
                        DisableGameButton(Columns[i].Cells[j + 3].Player.Name);
                        return;
                    }
                }
            }
            for (int i = 0; i < Width; i++)
            {
                for (int j = 0; j < Height - 3; j++)
                {
                    if (Columns[i].Cells[j].Player == Columns[i].Cells[j + 1].Player &&
                        Columns[i].Cells[j].Player == Columns[i].Cells[j + 2].Player &&
                        Columns[i].Cells[j].Player == Columns[i].Cells[j + 3].Player &&
                        Columns[i].Cells[j].Player != null)
                    {
                        DisableGameButton(Columns[i].Cells[j].Player.Name);
                        return;
                    }
                }
            }
            //for (int i = 0; i < Width - 3; i++)
            //{
            //    for (int j = 0; j < Height - 3; j++)
            //    {
            //        if (Columns[i].Cells[j].Player == Columns[i + 1].Cells[j + 1].Player &&
            //            Columns[i].Cells[j].Player == Columns[i + 2].Cells[j + 2].Player &&
            //            Columns[i].Cells[j].Player == Columns[i + 3].Cells[j + 3].Player &&
            //            Columns[i].Cells[j].Player != null)
            //        {
            //            DisableGameButton(Columns[i].Cells[j].Player.Name);
            //        }
            //    }
            //    for (int j = 0; j < Height - 3; j++)
            //    {
            //        if (Columns[i].Cells[j + 3].Player == Columns[i + 1].Cells[j + 2].Player &&
            //            Columns[i].Cells[j + 3].Player == Columns[i + 2].Cells[j + 1].Player &&
            //            Columns[i].Cells[j + 3].Player == Columns[i + 3].Cells[j].Player &&
            //            Columns[i].Cells[j + 3].Player != null)
            //        {
            //            DisableGameButton(Columns[i].Cells[j + 3].Player.Name);
            //        }
            //    }
            //}
        }

        private void DisableGameButton(string name)
        {
            for (int i = 0; i < Columns.Length; i++)
            {
                Columns[i].Btn.IsEnabled = false;
            }
            PrintWinner(name);
        }

        private async void PrintWinner(string text)
        {
            TextBlock winTbl = (TextBlock)MainGrid.FindName("winTbl");
            winTbl.Text = text + " Wins";
            MessageDialog message = new MessageDialog($"The Winner is - {text} \n\nDo you wont to play again?", "Game Over");
            message.Commands.Add(new UICommand("Yes Again!!!", ClearDialog));
            message.Commands.Add(new UICommand("No, Go Back", returnDialog));
            await message.ShowAsync();
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
                PrintWinner("No one. Its a tie!");
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
                MoveRect();
            }
        }

        public void StartGame()
        {
            Clear();
            ActivcePlayer = Player1;
            MoveRect();
        }

        void MoveRect()
        {
            Player1.RectanglePlayer.Visibility = Player2.RectanglePlayer.Visibility = Visibility.Collapsed;
            ActivcePlayer.RectanglePlayer.Visibility = Visibility.Visible;
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

        public void ClearDialog(IUICommand cmd)
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
        public void returnDialog(IUICommand cmd)
        {

            StartGrid.Visibility = Visibility.Visible;
            MainGrid.Visibility = Visibility.Collapsed;
        }
    }
}
