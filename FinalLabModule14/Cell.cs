using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Shapes;

namespace FinalLabModule14
{
    public class Cell
    {
        //private int _row;
        //private int _col;

        //public int Row 
        //{ 
        //    get { return _row; } 
        //    private set { _row = value; } 
        //}

        //public int GetRow()
        //{
        //    if (_row <= 0)
        //    {
        //        return 1;
        //    }
        //    return _row;
        //}
        //private void SetRow(int value)
        //{
        //    if(value <= 0)
        //    {
        //        value = Math.Abs(value);
        //    }
        //    _row = value;
        //}
        //private Ellipse _elps;
        //{ 
        //    get
        //    {
        //        if(_elps == null)
        //        {
        //            _elps = new Ellipse();
        //            _elps.HorizontalAlignment = HorizontalAlignment.Stretch;
        //            _elps.VerticalAlignment = VerticalAlignment.Stretch;
        //            _elps.Fill = new SolidColorBrush(Colors.White);
        //        }
        //        return _elps;
        //    } 
        //    private set
        //    {
        //        if(value != null)
        //        {
        //            _elps = value;
        //        }
        //    }
        //}

        public int Row { get; private set; }
        public int Col { get; private set; }
        public Ellipse Elps { get; private set; }
        private Player _player;

        public Player Player
        {
            get { return _player; }
            set { 
                _player = value;
                Elps.Fill = _player.Color;
            }
        }


        public Cell(int row, int col)
        {
            Row = row;
            Col = col;
            Elps = new Ellipse();
            Elps.HorizontalAlignment = HorizontalAlignment.Stretch;
            Elps.VerticalAlignment = VerticalAlignment.Stretch;
            Elps.Fill = new SolidColorBrush(Colors.White);
        }
    }
}
