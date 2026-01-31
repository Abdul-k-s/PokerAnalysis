using PokerAnalysis.ViewModels;
using PokerAnalysis.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Xps.Serialization;
using PokerAnalysis.Views;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Reactive.Concurrency;
using System.Windows.Controls;

namespace PokerAnalysis.Commands
{
    public class FinishInputCommand : CommandBase
    {

        private readonly TodoViewModel _todoViewModel;

        public FinishInputCommand(TodoViewModel vm)
        {
            _todoViewModel=vm;
        }
        private int[] _playersArr;

        public int[] PlayersArr
        {
            get { return _playersArr; }
            set { _playersArr = value; }
        }
        private int[] _handsArr;

        public  int[] HandsArr
        {
            get { return _handsArr; }
            set { _handsArr = value; }
        }
        public ObservableCollection<PlayerResult> PlayersResults { get; set; }
        public HandResult HandResults { get; set; }



        public override void Execute(object? parameter)
        {

            _playersArr =new int[7];
            _handsArr = new int[9];
            PlayersResults=new ObservableCollection<PlayerResult>();

            for (int i =0; i<_todoViewModel.NumLoops;i++)
            {
                MainProgram mainProgram = new MainProgram(_todoViewModel);
                recurr(mainProgram.GameResult);
            }

            HandResults = new HandResult(_handsArr,_todoViewModel.NumLoops);

            for (int i= 0; i < _playersArr.Count()-1 ;i++ )
            {
                PlayersResults.Add(new PlayerResult($"Player{i + 1}", _playersArr[i], _todoViewModel.NumLoops));
            }

            PlayersResults.Add(new PlayerResult($"Draw", _playersArr[6], _todoViewModel.NumLoops));
            _todoViewModel.PlayerStr = PlayersResults;
            _todoViewModel.HandStr = HandResults.HandDict;


        }



        //public void Evaluate((HandType, int, int)[] result)
        //{


        //        // if result[0] not equal result[1], result 0 wins
        //        if (result[0].Item1 != result[1].Item1 )
        //        {
        //            PlayersArr[result[0].Item3-1]++;
        //            HandsArr[(int)result[0].Item1]++;
        //        }
        //        // if result[0] hand type == result[1], Check item2 to see which hand is better

        //        else if (result[0].Item1 == result[1].Item1 && _todoViewModel.NumPlayers==0)
        //        {
        //            // if 0.item2 > 1.item2 , means 0 wins 
        //            if ((result[0].Item2 > result[1].Item2))
        //            {
        //                PlayersArr[result[0].Item3 - 1]++;
        //                HandsArr[(int)result[0].Item1]++;

        //            }
        //            // if not it's a draw
        //            else if ((result[0].Item2 == result[1].Item2) && result[2].Item2 == 0  )
        //            {
        //                PlayersArr[6]++;

        //                HandsArr[(int)result[0].Item1]++;
        //            }
        //            else
        //            {
        //                throw new InvalidOperationException("Something wrong with FinishInputCommand.Evaluate.item2");
        //            }

        //        }
        //        else if (result[0].Item1 == result[2].Item1 )
        //        {
        //            // if 0.item2 > 1.item2 , means 0 wins 

        //            if ((result[0].Item2 > result[1].Item2))
        //            {
        //                PlayersArr[result[0].Item3 - 1]++;
        //                HandsArr[(int)result[0].Item1]++;


        //            }
        //            // if 0.item2 > 2.item2 , means 0 ,1 wins 

        //            else if ((result[0].Item2 > result[2].Item2))
        //            {
        //                PlayersArr[result[0].Item3 - 1]++;
        //                PlayersArr[result[1].Item3 - 1]++;

        //                HandsArr[(int)result[0].Item1]++;
        //            }
        //            else if ((result[0].Item2 == result[2].Item2) && result[3].Item2 == 0)
        //            {


        //                PlayersArr[6]++;


        //                HandsArr[(int)result[0].Item1]++;
        //            }
        //            else
        //            {
        //                throw new InvalidOperationException("Something wrong with FinishInputCommand.Evaluate.item2");
        //            }

        //        }
        //        else if (result[0].Item1 == result[3].Item1 )
        //        {
        //            if ((result[0].Item2 > result[1].Item2))
        //            {
        //                PlayersArr[result[0].Item3 - 1]++;
        //                HandsArr[(int)result[0].Item1]++;


        //            }
        //            else if ((result[0].Item2 > result[2].Item2))
        //            {
        //                PlayersArr[result[0].Item3 - 1]++;
        //                PlayersArr[result[1].Item3 - 1]++;

        //                HandsArr[(int)result[0].Item1]++;
        //            }
        //            else if ((result[0].Item2 > result[3].Item2))
        //            {


        //                PlayersArr[result[0].Item3 - 1]++;
        //                PlayersArr[result[1].Item3 - 1]++;
        //                PlayersArr[result[2].Item3 - 1]++;

        //                HandsArr[(int)result[0].Item1]++;
        //            }
        //            else if ((result[0].Item2 == result[3].Item2) && result[4].Item2 == 0)
        //            {
        //                PlayersArr[6]++;


        //                HandsArr[(int)result[0].Item1]++;
        //            }
        //            else
        //            {
        //                throw new InvalidOperationException("Something wrong with FinishInputCommand.Evaluate.item2");
        //            }

        //        }
        //        else if (result[0].Item1 == result[4].Item1 && result[5].Item2 == 0)
        //        {
        //            if ((result[0].Item2 > result[1].Item2))
        //            {
        //                PlayersArr[result[0].Item3 - 1]++;
        //                HandsArr[(int)result[0].Item1]++;


        //            }
        //            else if ((result[0].Item2 > result[2].Item2))
        //            {
        //                PlayersArr[result[0].Item3 - 1]++;
        //                PlayersArr[result[1].Item3 - 1]++;

        //                HandsArr[(int)result[0].Item1]++;
        //            }
        //            else if ((result[0].Item2 > result[3].Item2))
        //            {


        //                PlayersArr[result[0].Item3 - 1]++;
        //                PlayersArr[result[1].Item3 - 1]++;
        //                PlayersArr[result[2].Item3 - 1]++;

        //                HandsArr[(int)result[0].Item1]++;
        //            }
        //            else if ((result[0].Item2 > result[3].Item2))
        //            {
        //                PlayersArr[result[0].Item3 - 1]++;
        //                PlayersArr[result[1].Item3 - 1]++;
        //                PlayersArr[result[2].Item3 - 1]++;
        //                PlayersArr[result[3].Item3 - 1]++;

        //                HandsArr[(int)result[0].Item1]++;
        //            }
        //            else if ((result[0].Item2 == result[4].Item2))
        //            {
        //                PlayersArr[6]++;


        //                HandsArr[(int)result[0].Item1]++;
        //            }
        //            else
        //            {
        //                throw new InvalidOperationException("Something wrong with FinishInputCommand.Evaluate.item2");
        //            }

        //        }

        //        else if (result[0].Item1 == result[5].Item1 && result.Length > 5)
        //        {

        //            PlayersArr[6]++; // It's a Draw
        //            HandsArr[(int)result[0].Item1]++;
        //        }

        //        else
        //        {
        //            throw new InvalidOperationException("Something wrong with FinishInputCommand.Evaluate");
        //        }
        //}

        public void recurr((HandType, int, int)[] result, int breaker=0)
        {
            if (breaker < _todoViewModel.NumPlayers-1)
            {
                if (result[breaker].Item1 != result[breaker + 1].Item1)
                {
                    for (int i = 0; i < breaker+1; i++)
                    {
                        PlayersArr[result[i].Item3 - 1]++;
                    }
                    ///
                    HandsArr[(int)result[0].Item1]++;
                }

                else
                {
                    recurr(result, breaker + 1);
                }
            }

            else
            {
                PlayersArr[6]++;
            }
        }
    }
}
