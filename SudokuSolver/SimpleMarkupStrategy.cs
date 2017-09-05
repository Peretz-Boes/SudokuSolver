using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SudokuSolver
{
    class SimpleMarkupStrategy:ISudokuStrategy
    {
        private readonly SudokuMapper SudokuMapper;
        public SimpleMarkupStrategy(SudokuMapper sudokuMapper)
        {
            SudokuMapper = sudokuMapper;
        }

        public int[,] Solve(int[,] sudokuBoard) {
            for (int row = 0; row < sudokuBoard.GetLength(0); row++)
            {
                for (int column = 0; column < sudokuBoard.GetLength(1); row++) {
                    if (sudokuBoard[row, column] == 0||sudokuBoard[row,column].ToString().Length>1) {
                        var possibilitesInRowAndColumn = GetPossibilitiesInRowAndColumn(sudokuBoard, row, column);
                        var possibilitiesInBlock = GetPossibilitiesInBlock(sudokuBoard, row, column);
                        sudokuBoard[row, column] = GetPossibilityIntersection(possibilitesInRowAndColumn, possibilitiesInBlock);
                    }
                }
            }
            return sudokuBoard;
        }

        private int GetPossibilitiesInRowAndColumn(int[,] sudokuBoard, int row, int column)
        {
            int[] possibilities = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            for (int col = 0; col < 9; col++) {
                if (isValidSingle(sudokuBoard[row, col])) {
                    possibilities[sudokuBoard[row, col] - 1] = 0;
                }
            }

            for (int col = 0; col < 9; col++)
            {
                if (isValidSingle(sudokuBoard[row, col]))
                {
                    possibilities[sudokuBoard[row, column] - 1] = 0;
                }
            }
            return Convert.ToInt32(String.Join(string.Empty, possibilities.Select(p => p).Where(p => p != 0)));
        }

        private int GetPossibilitiesInBlock(int[,] sudokuBoard, int givenRow, int givenColumn)
        {
            int[] possibilities = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            SudokuMap sudokuMap = SudokuMapper.Find(givenRow, givenColumn);
            for (int row = sudokuMap.StartRow; row < sudokuMap.StartColumn + 2; row++)
            {
                for (int col = sudokuMap.StartColumn; col < sudokuMap.StartColumn + 2; col++)
                {
                    if (isValidSingle(sudokuBoard[row, col]))
                    {
                        possibilities[sudokuBoard[row, col] - 1] = 0;
                    }
                }
            }
            return Convert.ToInt32(String.Join(string.Empty, possibilities.Select(p => p).Where(p => p != 0)));
        }

        private int GetPossibilityIntersection(int possibilitiesInRowAndColumn, int possibilitesInBlock)
        {
            var possibilitiesInRowAndColumnCharacterArray = possibilitiesInRowAndColumn.ToString().ToCharArray();
            var possibilitiesInBlockCharacterArray = possibilitiesInRowAndColumn.ToString().ToCharArray();
            var possibilitiesSubset = possibilitiesInRowAndColumnCharacterArray.Intersect(possibilitiesInBlockCharacterArray);
            return Convert.ToInt32(string.Join(string.Empty, possibilitiesSubset));
        }

        private bool isValidSingle(int cellDigit) {
            return cellDigit != 0 && cellDigit.ToString().Length < 2;
        }

    }
}
