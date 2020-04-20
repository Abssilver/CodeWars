using System;
using System.Collections.Generic;
using System.Text;

/*
If we were to set up a Tic-Tac-Toe game,
we would want to know whether the board's current state is solved, wouldn't we?
Our goal is to create a function that will check that for us!

Assume that the board comes in the form of a 3x3 array,
where the value is 0 if a spot is empty, 1 if it is an "X", or 2 if it is an "O", like so:

[[0, 0, 1],
 [0, 1, 2],
 [2, 1, 0]]
We want our function to return:

-1 if the board is not yet finished (there are empty spots),
1 if "X" won,
2 if "O" won,
0 if it's a cat's game (i.e. a draw).
You may assume that the board passed in is valid in the context of a game of Tic-Tac-Toe.
*/

namespace CodeWars
{
    class Kyu_5_Tic_Tac_Toe_Checker
    {
        public int IsSolved(int[,] board)
        {
            List<int> strokeTicTacSymbols = new List<int>();
            foreach (var item in board)
                strokeTicTacSymbols.Add(item);
            int result = FastRowSearcher(strokeTicTacSymbols);
            result = result == 0 ? FastDiagonalSearcher(strokeTicTacSymbols) : result;
            return result == 0 ? strokeTicTacSymbols.Contains(0) ? -1 : 0 : result;
        }
        int FastRowSearcher(List<int> strokeTicTacSymbols)
        {
            for (int rank = 0; rank < 7; rank += 3)
            {
                if (strokeTicTacSymbols[rank] != 0 &&
                    strokeTicTacSymbols[rank] == strokeTicTacSymbols[rank + 1] &&
                    strokeTicTacSymbols[rank] == strokeTicTacSymbols[rank + 2])
                    return strokeTicTacSymbols[rank];
            }
            for (int row = 0; row < 3; row++)
            {
                if (strokeTicTacSymbols[row] != 0 &&
                    strokeTicTacSymbols[row] == strokeTicTacSymbols[row + 3] &&
                    strokeTicTacSymbols[row] == strokeTicTacSymbols[row + 6])
                    return strokeTicTacSymbols[row];
            }
            return 0;
        }
        int FastDiagonalSearcher(List<int> strokeTicTacSymbols)
        {
            if (strokeTicTacSymbols[0] != 0 &&
                strokeTicTacSymbols[0] == strokeTicTacSymbols[4] &&
                strokeTicTacSymbols[0] == strokeTicTacSymbols[8])
                return strokeTicTacSymbols[0];
            else
                if (strokeTicTacSymbols[2] != 0 &&
                    strokeTicTacSymbols[2] == strokeTicTacSymbols[4] &&
                    strokeTicTacSymbols[2] == strokeTicTacSymbols[6])
                return strokeTicTacSymbols[2];
            return 0;
        }
    }
}
