using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using PokerAnalysis.Models;
using PokerAnalysis.ViewModels;

namespace PokerAnalysis.Models
{
    public class SortHands
    {

        private List<CardCollection> _players;

        public List<CardCollection> Players
        {
            get { return _players; }
            set { _players = value; }
        }

        private readonly TodoViewModel _todoViewModel;

        public SortHands(MainProgram mainProgram)
        {
           
            MainProgram _mainProgram = mainProgram ;
            _players= new List<CardCollection>();

            _players.AddRange(_mainProgram.Players);

            foreach (CardCollection player in _players)
            {
                player.Add(_mainProgram.River);
                player.Sort();
                if(player.Cards.Count() != 7) 
                {
                    throw new ArgumentException("Something went wrong!!! ");
                }
            }
            
        }

    }
}
