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
    public class Player
    {
        public string Name { get; set; }
        public Brush Color { get; set; }
        public Rectangle RectanglePlayer { get; set; }

        public Player()
        {
            RectanglePlayer = new Rectangle();
            Grid.SetRowSpan(RectanglePlayer, 2);
            Grid.SetColumnSpan(RectanglePlayer, 2);
            RectanglePlayer.Stroke = new SolidColorBrush(Colors.Yellow);
            RectanglePlayer.Visibility = Visibility.Collapsed;
        }
    }
}
