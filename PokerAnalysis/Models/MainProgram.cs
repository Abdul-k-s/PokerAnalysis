using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using PokerAnalysis.Commands;
using PokerAnalysis.ViewModels;

namespace PokerAnalysis.Models
{
    public class MainProgram
    {
        private readonly TodoViewModel _todoViewModel;

        private List<TodoItemViewModel> _deck;
        private List<TodoItemViewModel> _randomCards=new List<TodoItemViewModel>();
        private List<List<TodoItemViewModel>> _players;
        private List<TodoItemViewModel> _river;

        public List<CardCollection> Players { get;  }
        public CardCollection Deck { get;  }
        public CardCollection River { get;  }

        private int _loopNum;

        public int LoopNum
        {
            get { return _loopNum; }
            set { _loopNum = value; }
        }

        private int _playerNum;

        public int PlayerNum
        {
            get { return _playerNum; }
            set { _playerNum = value; }
        }
        int[] HandsResult = new int[8];
        private (HandType, int, int)[] _gameResult;

        public (HandType, int, int)[] GameResult
        {
            get { return _gameResult; }
            set { _gameResult = value; }
        }

        public MainProgram(TodoViewModel todoViewModel)
        {
            (HandType, int, int)[] GameResult = new (HandType,int,int)[6];

            _todoViewModel = todoViewModel;
            _deck = _todoViewModel.Deck.TodoItemViewModels.ToList();
            _river = _todoViewModel.River.TodoItemViewModels.ToList();
            _players = CreatePlayersList(_todoViewModel);
            _playerNum = _todoViewModel.NumPlayers;
            _loopNum = _todoViewModel.NumLoops;
            Players = new List<CardCollection>();


            for (int i = 5; i >= _todoViewModel.NumPlayers; i--)
            {
                if (_players[i].Count() != 0)
                {
                    foreach (var p in _players[i])
                    {
                        _deck.Add(p);
                    }
                }
                _players.Remove(_players[i]);
            }

            int tot = _players.Count() * 2 + 5;
            int diff = 52 - _deck.Count();
            while (diff < tot)
            {
                Random R= new Random(); 
                int randomNumber=R.Next(0, _deck.Count());
                _randomCards.Add(_deck[randomNumber]);
                _deck.Remove(_deck[randomNumber]);
                diff = 52 - _deck.Count();
            }

            while(_river.Count() < 5)
            {
                _river.Add(_randomCards.First());
                _randomCards.Remove(_randomCards.First());
            }
            foreach (var player in _players)
            {
                while (player.Count() < 2)
                {
                    player.Add(_randomCards.First());
                    _randomCards.Remove(_randomCards.First());
                }
            }

            Deck = ConvertToCards(_randomCards, "Deck");
            River = ConvertToCards(_river, "River");

            foreach (var p in _players)
            {
                Players.Add(ConvertToCards(p, $"Player{_players.IndexOf(p)+1}"));
            }
            MainEngine mainEngine = new MainEngine(this);
            
        }









        public List<List<TodoItemViewModel>> CreatePlayersList(TodoViewModel todoViewModel)
        {
            return new List<List<TodoItemViewModel>>{
                _todoViewModel.Player1.TodoItemViewModels.ToList(),
                _todoViewModel.Player2.TodoItemViewModels.ToList(),
                _todoViewModel.Player3.TodoItemViewModels.ToList(),
                _todoViewModel.Player4.TodoItemViewModels.ToList(),
                _todoViewModel.Player5.TodoItemViewModels.ToList(),
                _todoViewModel.Player6.TodoItemViewModels.ToList() };
        }

        public  CardCollection ConvertToCards(List<TodoItemViewModel> ViewModel,string label)
        {
            CardCollection values = new CardCollection(label);
            foreach (TodoItemViewModel todoItemViewModel in ViewModel)
            {
                values.Add(new Card(todoItemViewModel.Cardstr));
            }
            return values;
        }
        

    }
}
