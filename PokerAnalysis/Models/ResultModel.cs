using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerAnalysis.Models
{
    public class PlayerResult
    {
        public string Label { get; }
        public int Win { get; }
        public string WinsPercentage { get; }
        public PlayerResult(string label, int wins, int loops)
        {
            Label = label;
            Win = wins;
            WinsPercentage = ((float)wins / loops * 100).ToString("F2") + '%';

        }
        public override string ToString()
        {
            return $"{Label}: {Win} {WinsPercentage}";
        }
    }
    public class HandResult
    {

        public ObservableCollection<Tuple<string, int,string>> HandDict { get; }

        public HandResult(int[] hands ,int loops)
        {

            HandDict = new ObservableCollection<Tuple<string, int, string>>();
            HandDict.Add(new Tuple<string, int, string>("HighCard", hands[0], HandPercentage(hands[0], loops)));
            HandDict.Add(new Tuple<string, int, string>("Pair", hands[1], HandPercentage(hands[1], loops)));
            HandDict.Add(new Tuple<string, int, string>("TwoPair", hands[2], HandPercentage(hands[2], loops)));
            HandDict.Add(new Tuple<string, int, string>("ThreeOfKind", hands[3], HandPercentage(hands[3], loops)));
            HandDict.Add(new Tuple<string, int, string>("Straight", hands[4], HandPercentage(hands[4], loops)));
            HandDict.Add(new Tuple<string, int, string>("Flush", hands[5], HandPercentage(hands[5], loops)));
            HandDict.Add(new Tuple<string, int, string>("FullHouse", hands[6], HandPercentage(hands[6], loops)));
            HandDict.Add(new Tuple<string, int, string>("FourOfKind", hands[7], HandPercentage(hands[7], loops)));
            HandDict.Add(new Tuple<string, int, string>("StraightFlush", hands[8], HandPercentage(hands[8], loops)));



        }
        public string HandPercentage(int hands ,int loops)
        {
            return((float)hands / loops * 100).ToString("F2") + '%';
        }

    }
}
