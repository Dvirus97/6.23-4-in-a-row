using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace FinalLabModule14
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private Board brd;
        public MainPage()
        {
            this.InitializeComponent();
            brd = new Board(mainGrid);
            //int col = mainGrid.ColumnDefinitions.Count;
        }

        private void Start_Tapped(object sender, TappedRoutedEventArgs e)
        {
            //colorP1Cbx_DropDownClosed(null,null) ;
            //colorP2Cbx_DropDownClosed(null, null);
            //brd.Player1.Name = (nameP1Tbx.Text=="") ? $"Plyer {brd.Player1.Color}" : nameP1Tbx.Text ;
            //brd.Player2.Name = (nameP2Tbx.Text=="") ? $"Plyer {brd.Player2.Color}" : nameP2Tbx.Text ;
            startGrid.Visibility = Visibility.Collapsed;
            mainGrid.Visibility = Visibility.Visible;
            SetBoard();
            brd.StartGame();
        }

        private void colorP1Cbx_DropDownClosed(object sender, object e)
        {
            ComboBoxItem cbi = ((ComboBoxItem)colorP1Cbx.SelectedItem == null) ? 
                BlueCbi : (ComboBoxItem)colorP1Cbx.SelectedItem;
            colorP1Cbx.Background =  cbi.Background;
            brd.Player1.Color = colorP1Cbx.Background;
        }
        private void colorP2Cbx_DropDownClosed(object sender, object e)
        {

            ComboBoxItem cbi = ((ComboBoxItem)colorP1Cbx.SelectedItem == null) ? 
                RedCbi : (ComboBoxItem)colorP2Cbx.SelectedItem;
            colorP2Cbx.Background =  cbi.Background;
            brd.Player2.Color = colorP2Cbx.Background;
        }

        private void SetBoard()
        {
            colorP1Cbx_DropDownClosed(null, null);
            colorP2Cbx_DropDownClosed(null, null);
            brd.Player1.Name = (nameP1Tbx.Text == "") ? $"Player Blue" : nameP1Tbx.Text;
            brd.Player2.Name = (nameP2Tbx.Text == "") ? $"Player Red" : nameP2Tbx.Text;
            //showColor1Tbl.Text = brd.Player1.Color.ToString();
            //showColor1Tbl.FocusVisualPrimaryBrush = brd.Player1.Color;

            //showColor2Tbl.Text = brd.Player2.Color.ToString();
            //showColor2Tbl.FocusVisualPrimaryBrush = brd.Player2.Color;

            showName1Tbl.Text = brd.Player1.Name;

            showName2Tbl.Text = brd.Player2.Name;
        }
    }
}
