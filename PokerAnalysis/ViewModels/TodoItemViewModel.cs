 using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace PokerAnalysis.ViewModels
{
    public class TodoItemViewModel : ViewModelBase
    {
        private string _cardstr;
        private SolidColorBrush _cardclr;
        // Displaying Cards in WPF
        public string Cardstr
        {
            get { return _cardstr; }
            set
            {
                _cardstr = value;
                OnPropertyChanged(nameof(Cardstr));
            }
        }

        public SolidColorBrush Cardclr
        {
            get => _cardclr;

        }

        public TodoItemViewModel(string cardstr)
        {
            _cardstr=cardstr;
            switch (cardstr[0])
            {
                case '♣':
                case '♠':
                    _cardclr = new SolidColorBrush(Colors.Black);
                    break;
                case '♦':
                case '♥':
                    _cardclr = new SolidColorBrush(Colors.Red); break;
            }
        }
    }
}
