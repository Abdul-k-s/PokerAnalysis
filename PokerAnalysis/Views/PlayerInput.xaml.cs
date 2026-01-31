using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PokerAnalysis.Views
{
    /// <summary>
    /// Interaction logic for PlayerInput.xaml
    /// </summary>
    public partial class PlayerInput : UserControl
    {
        public int PlayerCount { get; set; }
        public int PlayerLoops { get; set; }


        public PlayerInput()
        {
           
            InitializeComponent();

        }

        // Get the number participants in the game
        private void Players_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            var slider = (Slider)sender;
            int value = (int) slider.Value;
            TextPlayerNo.Text = $"{value}";
            PlayerCount = value;
            RunTime.Text = $"Expected RunTime: {PlayerLoops * .00004 + PlayerLoops * .00004 * .15 * PlayerCount}";
        }

        // Get the number of loops for analysis
        private void Loops_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            var loopSLider = (Slider)sender;
            PlayerLoops = (int)loopSLider.Value;
            
            RunTime.Text = $"Expected RunTime: {PlayerLoops * .00004 + PlayerLoops * .00004 * .15 * PlayerCount}";

        }
    }
}
