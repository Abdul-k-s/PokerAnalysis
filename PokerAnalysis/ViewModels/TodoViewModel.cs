using PokerAnalysis.Commands;
using PokerAnalysis.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace PokerAnalysis.ViewModels
{
    public class TodoViewModel : ViewModelBase
    {
        public TodoItemListingViewModel Deck { get; }
        public TodoItemListingViewModel River { get; }
        public TodoItemListingViewModel Player1 { get; }
        public TodoItemListingViewModel Player2 { get; }
        public TodoItemListingViewModel Player3 { get; }
        public TodoItemListingViewModel Player4 { get; }
        public TodoItemListingViewModel Player5 { get; }
        public TodoItemListingViewModel Player6 { get; }


        public ICommand SubmitCommand { get; }
        public ICommand ClearCommand { get; }


        public TodoViewModel(TodoItemListingViewModel deck, TodoItemListingViewModel river, 
            ObservableCollection<TodoItemListingViewModel> players)
        {
            Deck = deck;
            River = river;
            Player1 = players[0];
            Player2 = players[1];
            Player3 = players[2];
            Player4 = players[3];
            Player5 = players[4];
            Player6 = players[5];

            _playerStr = new ObservableCollection<PlayerResult>();
            _handstr = new ObservableCollection<Tuple<string, int, string>>();

            SubmitCommand = new FinishInputCommand(this);
            ClearCommand = new ClearCommand();
        }
        
        private int _numPlayers;
        public int NumPlayers
        {
            get
            {
                return _numPlayers;
            }
            set
            {
                _numPlayers = value;
                OnPropertyChanged(nameof(NumPlayers));
            }
        }

        private int _numLoops;
        public int NumLoops
        {
            get
            {
                return _numLoops;
            }
            set
            {
                _numLoops = value;
                OnPropertyChanged(nameof(NumLoops));
            }
        }

        private ObservableCollection<PlayerResult> _playerStr;
        public ObservableCollection<PlayerResult> PlayerStr
        {
            get
            {
                return _playerStr;
            }
            set
            {
                _playerStr = value;
                OnPropertyChanged(nameof(PlayerStr));
            }
        }
        private ObservableCollection<Tuple<string, int, string>> _handstr;

        public ObservableCollection<Tuple<string, int, string>> HandStr
        {
            get { return _handstr; }
            set { 
                    _handstr = value; 
                    OnPropertyChanged(nameof(HandStr)); 
                }
        }


    }
}
