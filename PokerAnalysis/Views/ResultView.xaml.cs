using PokerAnalysis.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Interaction logic for ResultView.xaml
    /// </summary>
    public partial class ResultView : Window
    {
        public ResultView(ObservableCollection<PlayerResult> playerResults,HandResult handResults)
        {
            InitializeComponent();
            ViewModels.ResultViewModel resultViewModel = new ViewModels.ResultViewModel(playerResults, handResults);
            this.DataContext = resultViewModel;

        }
    }
}
