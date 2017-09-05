using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SudokuSolver
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                SudokuMapper sudokuMapper = new SudokuMapper();
                SudokuBoardStateManager sudokuBoardStateManager = new SudokuBoardStateManager();
                SudokuSolverEngine sudokuSolverEngine = new SudokuSolverEngine(sudokuBoardStateManager, sudokuMapper);
                SudokuFileReader sudokuFileReader = new SudokuFileReader();
                SudokuBoardDisplayer sudokuBoardDisplayer = new SudokuBoardDisplayer();
                Console.WriteLine("Enter the name of the file with the Sudoku puzzle.");
                string filename = Console.ReadLine();
                int[,] sudokuBoard = sudokuFileReader.ReadFile(filename);
                sudokuBoardDisplayer.Display("Initial state:", sudokuBoard);
                bool isSudokuSolved = sudokuSolverEngine.Solve(sudokuBoard);
                sudokuBoardDisplayer.Display("Final state", sudokuBoard);
                Console.WriteLine(isSudokuSolved ? "You have successfully solved this Sudoku puzzle" : "Unfortunately current algorithm(s) were not enough to solve the current Sudoku puzzle.");
            }
            catch (Exception exception)
            {
                Console.WriteLine("Error solving the Sudoku puzzle " + exception.Message);
            }
            Console.ReadLine();
        }
    }
}
