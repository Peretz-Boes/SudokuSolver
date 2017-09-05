using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SudokuSolver
{
    class SudokuBoardDisplayer
    {
        public void Display(string title, int[,] sudokuBoard) {
            if (!title.Equals(string.Empty)) {
                Console.WriteLine("{0} {1}", title, Environment.NewLine);
            }
            for (int row = 0; row < sudokuBoard.GetLength(0); row++) {
                Console.Write("|");
                for (int column = 0; column < sudokuBoard.GetLength(0); column++)
                {
                    Console.Write("{0}{1}", sudokuBoard[row, column] + "|");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }
    }
}
