using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Documents;

namespace PokerAnalysis.Models
{
    public class Evaluter
    {



        public Evaluter(MainProgram mainProgram)
        {
            int[] HandsResult = new int[8];

            for (int i = 0; i < 1; i++)
            {
                MainEngine mainEngine = new MainEngine(mainProgram);
                List<(HandType, int, int)> result;
                result = mainEngine.EvaluationResult.OrderByDescending(t => t.Item1).ThenByDescending(t => t.Item2).ToList();

                if (result[0].Item1 == result[1].Item1 && result.Count > 1)
                {
                    mainProgram.PlayersResult[0]++;
                    mainProgram.PlayersResult[1]++;

                    HandsResult[(int)result[0].Item1]++;
                }
                else if (result[0].Item1 == result[2].Item1 && result.Count > 2)
                {
                    mainProgram.PlayersResult[0]++;
                    mainProgram.PlayersResult[1]++;
                    mainProgram.PlayersResult[2]++;

                    HandsResult[(int)result[0].Item1]++;
                }
                else if (result[0].Item1 == result[3].Item1 && result.Count > 3)
                {
                    mainProgram.PlayersResult[0]++;
                    mainProgram.PlayersResult[1]++;
                    mainProgram.PlayersResult[2]++;
                    mainProgram.PlayersResult[3]++;

                    HandsResult[(int)result[0].Item1]++;
                }
                else if (result[0].Item1 == result[4].Item1 && result.Count > 4)
                {
                    mainProgram.PlayersResult[0]++;
                    mainProgram.PlayersResult[1]++;
                    mainProgram.PlayersResult[2]++;
                    mainProgram.PlayersResult[3]++;
                    mainProgram.PlayersResult[4]++;

                    HandsResult[(int)result[0].Item1]++;
                }
                else if (result[0].Item1 == result[5].Item1 && result.Count > 5)
                {
                    mainProgram.PlayersResult[5]++; // It's a Draw
                    HandsResult[(int)result[0].Item1]++;
                }

                else
                {
                    mainProgram.PlayersResult[0]++;
                    HandsResult[(int)result[0].Item1]++;
                }
            }





        }
    }
}

