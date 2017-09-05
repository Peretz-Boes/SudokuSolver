using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SudokuSolver
{
    class SudokuBoardStateManager
    {
        public string GenerateState(int[,] sudokuBoard) {
            StringBuilder key = new StringBuilder();
            for (int row = 0; row < sudokuBoard.GetLength(0); row++)
            {
                for (int column = 0; column < sudokuBoard.GetLength(0); column++)
                {
                    key.Append(sudokuBoard[row, column]);
                }
            }
            return key.ToString();
        }

        public bool isSolved(int[,] sudokuBoard) {
            for (int row = 0; row < sudokuBoard.GetLength(0); row++)
            {
                for (int column = 0; column < sudokuBoard.GetLength(0); column++)
                {
                    if (sudokuBoard[row, column] == 0 || sudokuBoard[row, column].ToString().Length > 1) {
                        return false;
                    }
                }
                
            }
            return true;
        }

    }
}
