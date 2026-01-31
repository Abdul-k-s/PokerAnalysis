
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerAnalysis.Models
{
    public class Card : IComparable<Card>
    {

        public int Rank { get; }
        public Char Suit { get; }

        public Card(Char suit, int rank)
        {
            Suit = suit;
            Rank = rank;
        }

        public override string ToString()
        {
            string tempValue = "";

            switch (Rank)
            {
                case 11:
                    tempValue = "J";
                    break;
                case 12:
                    tempValue = "Q";
                    break;
                case 13:
                    tempValue = "K";
                    break;
                case 14:
                    tempValue = "A";
                    break;
                default:
                    tempValue = Rank.ToString();
                    break;
            }

            return $"{Suit}_{tempValue}";
        }



        public Card(string input)
        {

            char tempValue = input[1];
            char suitSentence = input[0];

            switch (tempValue)
            {
                case 'J':
                    Rank = 11;
                    break;
                case 'Q':
                    Rank = 12;
                    break;
                case 'K':
                    Rank = 13;
                    break;
                case 'A':
                    Rank = 14;
                    break;
                case '1':
                    Rank = 10;
                    break;
                default:
                    Rank = tempValue - '0';
                    break;
            }
            Suit = input[0];


        }

        public int CompareTo(Card? other)
        {
            if (this?.Rank < other?.Rank)
            {
                return 1;
            }
            else if (this?.Rank > other?.Rank)
            {
                return -1;
            }
            else
            {
                return 0;
            }
        }

        public static bool operator ==(Card? lhs, Card? rhs)
        {
            if (lhs is null || rhs is null) return false;
            return lhs.Rank.Equals(rhs.Rank);
        }
        public static bool operator != (Card? lhs, Card? rhs)
        {
            return !(lhs.Rank.Equals(rhs.Rank));
        }
    }
}
