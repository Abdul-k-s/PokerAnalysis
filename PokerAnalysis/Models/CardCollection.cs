using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace PokerAnalysis.Models
{
    public class CardCollection
    {
        public List<Card> Cards { get; set; }
        public string Label { get; }
        public int ID { get; }


        public CardCollection(string label)
        {
            Cards = new List<Card>();
            Label = label;
            if(Char.IsNumber(label.Last()))
            {
                ID = label.Last() - '0';
            }
            else { ID=0; }
        }

        public void Add(Card card) 
        { 
            Cards.Add(card);
        }
        public void Add(CardCollection cards)
        {
            Cards.AddRange(cards.Cards);
        }

        public override string ToString()
        {
            return Label;
        }

        public string ToString(bool b)
        {
            string cardstr = "";
            foreach (Card card in Cards)
            {
                cardstr=cardstr+"  "+card.ToString();
            }
            return cardstr;
        }
        public List<Card> SortBySuit()
        {
            return Cards.OrderBy(x => x.Suit).ToList();
        }
        public void Sort()
        {
            Cards.Sort();
        }
    }
}
