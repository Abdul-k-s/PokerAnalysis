using System;
using System.Collections.Generic;
using System.DirectoryServices.ActiveDirectory;
using System.Linq;
using System.Numerics;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace PokerAnalysis.Models
{
    public class MainEngine
    {
        private List<CardCollection> _players;

        private (HandType, int, int)[] _evaluationResult;

        public (HandType, int, int)[] EvaluationResult
        {
            get { return _evaluationResult; }
            set { _evaluationResult = value; }
        }



        public MainEngine(MainProgram mainProgram) 
        { 
            SortHands sortHands = new SortHands(mainProgram);
            _players = sortHands.Players;
            mainProgram.GameResult = new (HandType, int, int)[6] ;
            for (int i=0;i<_players.Count;i++)
            {
                mainProgram.GameResult[i] = HandEvaluater(_players[i]);
            }
            mainProgram.GameResult= mainProgram.GameResult.OrderByDescending(t => t.Item1).ThenByDescending(t => t.Item2).ToArray();

        }

        public (HandType,int,int) HandEvaluater(CardCollection player)
        {
            List<Card> sortedbysuit = player.SortBySuit();
            (bool, int) flushchecker = CheckForFlush(sortedbysuit);
            (bool,int,int,int) pairChecker = CheckForPair(player.Cards);
            (bool, int) straightChecker = StraightChecker(player.Cards);
            (bool, int) straightFlushChecker = StraightChecker(sortedbysuit);



            #region StraightFlush
            if (flushchecker.Item1 == true && straightFlushChecker.Item1==true) //Case of Straight Flush
            {
                return (HandType.StraightFlush, straightFlushChecker.Item2, player.ID);
            }
            #endregion

            #region Four Of Kind


            else if (player.Cards[0] == player.Cards[1] && player.Cards[1] == player.Cards[2]
                && player.Cards[2] == player.Cards[3]) // Case Four of Kind
            {
                int factor = player.Cards[0].Rank * 10 + player.Cards[4].Rank;
                return (HandType.FourOfKind, factor,player.ID);
            }
            else if (player.Cards[1] == player.Cards[2] && player.Cards[2] == player.Cards[3]
                 && player.Cards[3] == player.Cards[4]) // Case Four of Kind
            {
                int factor = player.Cards[1].Rank * 10 + player.Cards[0].Rank;
                return (HandType.FourOfKind, factor, player.ID);
            }
            else if (player.Cards[2] == player.Cards[3] && player.Cards[3] == player.Cards[4]
                && player.Cards[4] == player.Cards[5]) // Case Four of Kind
            {
                int factor = player.Cards[2].Rank * 10 + player.Cards[0].Rank;
                return (HandType.FourOfKind, factor, player.ID);
            }
            else if (player.Cards[3] == player.Cards[4] && player.Cards[4] == player.Cards[5]
                && player.Cards[5] == player.Cards[6]) // Case Four of Kind
            {
                int factor = player.Cards[3].Rank * 10 + player.Cards[0].Rank;
                return (HandType.FourOfKind, factor, player.ID);
            }
            #endregion
            // A A A 2 2    = (14 14 14)*10 2 2
            // k k k  q q  = 13 13 13 12 12
            #region FullHouse
            else if (player.Cards[0] == player.Cards[1] && player.Cards[1] == player.Cards[2])
            {
                if (player.Cards[3] == player.Cards[4])
                {
                    int factor = player.Cards[0].Rank * 2 + player.Cards[4].Rank;
                    return (HandType.FullHouse, factor, player.ID);
                }
                else if (player.Cards[4] == player.Cards[5])
                {
                    int factor = player.Cards[0].Rank * 2 + player.Cards[4].Rank;
                    return (HandType.FullHouse, factor, player.ID);
                }
                else if (player.Cards[5] == player.Cards[6])
                {
                    int factor = player.Cards[0].Rank * 2 + player.Cards[5].Rank;
                    return (HandType.FullHouse, factor, player.ID);
                }
            }
            else if (player.Cards[1] == player.Cards[2] && player.Cards[2] == player.Cards[3])
            {
                if (player.Cards[4] == player.Cards[5])
                {
                    int factor = player.Cards[1].Rank * 2 + player.Cards[4].Rank;
                    return (HandType.FullHouse, factor, player.ID);
                }

                else if (player.Cards[5] == player.Cards[6])
                {
                    int factor = player.Cards[1].Rank * 2 + player.Cards[5].Rank;
                    return (HandType.FullHouse, factor, player.ID);
                }
            }
            else if (player.Cards[2] == player.Cards[3] && player.Cards[3] == player.Cards[4])
            {
                if (player.Cards[0] == player.Cards[1])
                {
                    int factor = player.Cards[2].Rank * 2 + player.Cards[0].Rank;
                    return (HandType.FullHouse, factor, player.ID);
                }

                else if (player.Cards[5] == player.Cards[6])
                {
                    int factor = player.Cards[2].Rank * 2 + player.Cards[5].Rank;
                    return (HandType.FullHouse, factor, player.ID);
                }

            }
            else if (player.Cards[3] == player.Cards[4] && player.Cards[4] == player.Cards[5])
            {
                if(player.Cards[0] == player.Cards[1])
                {
                    int factor = player.Cards[3].Rank * 2 + player.Cards[0].Rank;
                    return (HandType.FullHouse, factor, player.ID);
                }
                else if (player.Cards[1] == player.Cards[2])
                {
                    int factor = player.Cards[3].Rank * 2 + player.Cards[1].Rank;
                    return (HandType.FullHouse, factor, player.ID);
                }
            }
            do
            {
                if (player.Cards[4] == player.Cards[5] && player.Cards[5] == player.Cards[6])
                {


                    if (player.Cards[0] == player.Cards[1])
                    {
                        int factor = player.Cards[3].Rank * 2 + player.Cards[0].Rank;
                        return (HandType.FullHouse, factor, player.ID);
                    }
                    else if (player.Cards[1] == player.Cards[2])
                    {
                        int factor = player.Cards[3].Rank * 2 + player.Cards[1].Rank;
                        return (HandType.FullHouse, factor, player.ID);
                    }
                    else if (player.Cards[2] == player.Cards[3])
                    {
                        int factor = player.Cards[4].Rank * 2 + player.Cards[2].Rank;
                        return (HandType.FullHouse, factor, player.ID);
                    }
                    else
                    {
                        break;
                    }

                }
            } while (false);

            #endregion

            #region Flush
            if (flushchecker.Item1 ==true) // Flush
            {
                return(HandType.Flush, flushchecker.Item2,player.ID);
            }
            #endregion

            #region Straight

            else if (straightChecker.Item1 == true) // Straight
            {
                return(HandType.Straight,straightChecker.Item2,player.ID);
            }

            #endregion

            #region ThreeOfKind
            else if (player.Cards[0] == player.Cards[1] && player.Cards[1] == player.Cards[2]) 
            {
                int factor= player.Cards[0].Rank*30 + player.Cards[3].Rank *2 + player.Cards[4].Rank;
                return(HandType.ThreeOfKind,factor,player.ID);
            }
            else if (player.Cards[1] == player.Cards[2] && player.Cards[2] == player.Cards[3])
            {
                int factor = player.Cards[1].Rank * 30 + player.Cards[0].Rank * 2 + player.Cards[4].Rank;
                return (HandType.ThreeOfKind, factor, player.ID);
            }
            else if (player.Cards[2] == player.Cards[3] && player.Cards[3] == player.Cards[4]) 
            {
                int factor = player.Cards[2].Rank * 30 + player.Cards[0].Rank * 2 + player.Cards[1].Rank;
                return (HandType.ThreeOfKind, factor, player.ID);
            }
            else if (player.Cards[3] == player.Cards[4] && player.Cards[4] == player.Cards[5]) 
            {
                int factor = player.Cards[3].Rank * 30 + player.Cards[0].Rank * 2 + player.Cards[1].Rank;
                return (HandType.ThreeOfKind, factor, player.ID);
            }
            else if (player.Cards[4] == player.Cards[5] && player.Cards[5] == player.Cards[6])
            {
                int factor = player.Cards[4].Rank * 30 + player.Cards[0].Rank * 2 + player.Cards[1].Rank;
                return (HandType.ThreeOfKind, factor, player.ID);
            }
            #endregion

            #region TwoPairs
            else if (pairChecker.Item1 == true && pairChecker.Item2 == 2) // Two Pairs
            {

                if(pairChecker.Item3 != 1)
                {
                    int factor = player.Cards[pairChecker.Item3 - 1].Rank * 50 + player.Cards[pairChecker.Item4 - 1].Rank * 10 + player.Cards[0].Rank;
                    return (HandType.TwoPairs, factor, player.ID);
                }

                else if (pairChecker.Item4 == 2)
                {
                    int factor = player.Cards[pairChecker.Item3 - 1].Rank * 50 + player.Cards[pairChecker.Item4 - 1].Rank * 10 + player.Cards[4].Rank;
                    return (HandType.TwoPairs, factor, player.ID);
                }
                else
                {
                    int factor = player.Cards[pairChecker.Item3 - 1].Rank * 50 + player.Cards[pairChecker.Item4 - 1].Rank * 10 + player.Cards[2].Rank;
                    return (HandType.TwoPairs, factor, player.ID);
                }

            }


            #endregion

            #region Pair
            else if (pairChecker.Item1 == true) // Pair
            {
                if (pairChecker.Item3 == 1)
                {
                    int factor = player.Cards[0].Rank * 300 + player.Cards[2].Rank * 100 +
                        player.Cards[3].Rank * 20 + player.Cards[4].Rank;
                    return (HandType.Pair, factor, player.ID);
                }
                else if (pairChecker.Item3 == 2)
                {
                    int factor = player.Cards[1].Rank * 300 + player.Cards[0].Rank * 100 +
                        player.Cards[3].Rank * 20 + player.Cards[4].Rank;
                    return (HandType.Pair, factor, player.ID);

                }
                else if (pairChecker.Item3 == 3)
                {
                    int factor = player.Cards[2].Rank * 300 + player.Cards[0].Rank * 100 +
                        player.Cards[1].Rank * 20 + player.Cards[4].Rank;
                    return (HandType.Pair, factor, player.ID);
                }
                else
                {
                    int factor = player.Cards[3].Rank * 300 + player.Cards[0].Rank * 100 +
                        player.Cards[1].Rank * 20 + player.Cards[2].Rank;
                    return (HandType.Pair, factor, player.ID);
                }
            }
            #endregion

            #region HighCard
            else
            {
                int factor = player.Cards[0].Rank * 6 + player.Cards[1].Rank * 4 + player.Cards[2].Rank * 3 + player.Cards[3].Rank * 2 + player.Cards[4].Rank;
                return (HandType.HighCard,factor, player.ID);
            }
            #endregion
            throw new Exception($"{player} Evaluation prob.");
            

        }

        public (bool,int) CheckForFlush(List<Card> cards)
        {
            if (cards[0].Suit == cards[1].Suit && cards[1].Suit == cards[2].Suit && cards[2].Suit == cards[3].Suit
                && cards[3].Suit == cards[4].Suit) 
            {
                int factor = cards[0].Rank * 6 + cards[1].Rank * 4 + cards[2].Rank * 3 + cards[3].Rank * 2 + cards[4].Rank  ;
                return (true, factor);
            }

            else if (cards[1].Suit == cards[2].Suit && cards[2].Suit == cards[3].Suit && cards[3].Suit == cards[4].Suit
                && cards[4].Suit == cards[5].Suit)
            {
                int factor = cards[1].Rank * 6 + cards[2].Rank * 4 + cards[3].Rank * 3 + cards[4].Rank * 2 + cards[5].Rank;
                return (true, factor);
            }

            else if (cards[2].Suit == cards[3].Suit && cards[3].Suit == cards[4].Suit && cards[4].Suit == cards[5].Suit
                && cards[5].Suit == cards[6].Suit)
            {
                int factor = cards[2].Rank * 6 + cards[3].Rank * 4 + cards[4].Rank * 3 + cards[5].Rank * 2 + cards[6].Rank;
                return (true, factor);
            }

            else
            {
                return (false, 0);
            }
        }

        public (bool,int,int,int) CheckForPair(List<Card> cards)
        {
            bool temp = false;
            int NumberOfPairs = 0;
            int y=0;
            int x = 0;
            int index = 0;

            if (cards[0] == cards[1]) { temp = true; NumberOfPairs++; y = 1; }
            if (cards[1] == cards[2] && NumberOfPairs != 2) { temp = true; NumberOfPairs++; if (y != 0) { x = 1; return (temp, NumberOfPairs, y, x); } else { y = 2; }; }
            if (cards[2] == cards[3] && NumberOfPairs != 2) { temp = true; NumberOfPairs++; if (y != 0) { x = 2; return (temp, NumberOfPairs, y, x); } else { y = 3; }; }
            if (cards[3] == cards[4] && NumberOfPairs != 2) { temp = true; NumberOfPairs++; if (y != 0) { x = 3; return (temp, NumberOfPairs, y, x); } else { y = 4; }; }
            if (cards[4] == cards[5] && NumberOfPairs != 2) { temp = true; NumberOfPairs++; if (y != 0) { x = 4; return (temp, NumberOfPairs, y, x); } else { y = 5; }; }
            if (cards[5] == cards[6] && NumberOfPairs != 2) { temp = true; NumberOfPairs++; if (y != 0) { x = 5; return (temp, NumberOfPairs, y, x); } else { y = 6; }; 
                return (temp, NumberOfPairs, y, x); }

            return (temp, NumberOfPairs, y, x);
        }

        public (bool, int) StraightChecker (List<Card> cards)
        {
            bool temp = false;
            int itemp = 0;
            int StraightNo = 0;
            int index = 0;

            while(StraightNo < 4 && index < 6)
            {
                if (cards[index].Rank-1 == cards[index+1].Rank)
                {
                    StraightNo++;
                }
                else if(cards[index].Rank - 1 == cards[index+1].Rank)
                {
                    continue;
                }
                else
                {
                    StraightNo=0;
                }
                index++;
                itemp = index;
            }
            if(StraightNo == 4)
            {
                return (true, cards[itemp - 4].Rank);
            }

            else if (cards[0].Rank==14 && cards.Exists(x=> x.Rank==2 && x.Rank==3 && x.Rank == 4 && x.Rank == 5))
            {
                return(true, 0);
            }
            else
            {
                return (false, 0);
            }
        }


    }
    public enum HandType
    {
        HighCard = 0, Pair, TwoPairs, ThreeOfKind, Straight, Flush, FullHouse, FourOfKind, StraightFlush
    }
}

