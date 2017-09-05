using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace SudokuSolver
{
    class SudokuFileReader
    {
        public int[,] ReadFile(string filename) {
            int[,] sudokuBoard = new int[9, 9];
            try
            {
                var sudokuBoardLines = File.ReadAllLines(filename);
                int row = 0;
                foreach (var sudokuBoardLine in sudokuBoardLines) {
                    string[] sudokuBoardLineElements = sudokuBoardLine.Split('|').Skip(1).Take(9).ToArray();
                    int column = 0;
                    foreach (var sudokuBoardLineElement in sudokuBoardLineElements) {
                        sudokuBoard[row, column] = sudokuBoardLineElement.Equals("") ? 0 : Convert.ToInt16(sudokuBoardLineElement);
                        column++;
                    }
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine("An error occured while reading the file " + exception.Message);
            }
            return sudokuBoard;
        }
    }
}
