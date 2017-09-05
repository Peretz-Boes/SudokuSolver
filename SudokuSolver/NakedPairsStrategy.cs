using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SudokuSolver
{
    class NakedPairsStrategy:ISudokuStrategy
    {
        private readonly SudokuMapper SudokuMapper;
        public NakedPairsStrategy(SudokuMapper sudokuMapper)
        {
            SudokuMapper = sudokuMapper;
        }

        public int[,] Solve(int[,] sudokuBoard) {
            for (int row = 0; row < sudokuBoard.GetLength(0); row++)
            {
                for (int column = 0; column < sudokuBoard.GetLength(0); column++)
                {
                    EliminateNakedPairFromOthersInRow(sudokuBoard, row, column);
                    EliminateNakedPairFromOthersInColumn(sudokuBoard, row, column);
                    EliminateNakedPairFromOthersInBlock(sudokuBoard, row, column);
                }
            }
            return sudokuBoard;
        }

        public void EliminateNakedPairFromOthersInRow(int[,] sudokuBoard, int givenRow, int givenCol) {
            if (!HasNakedPairInRow(sudokuBoard, givenRow, givenCol))
            {
                return;
            }
            else {
                for (int col = 0; col<sudokuBoard.GetLength(1); col++)
                {
                    if (sudokuBoard[givenRow, col] != sudokuBoard[givenRow, givenCol] && sudokuBoard[givenRow, col].ToString().Length > 1) {
                        EliminateNakedPair(sudokuBoard, sudokuBoard[givenRow, givenCol], givenRow, col);
                    }
                }
            }
        }

        private void EliminateNakedPair(int[,] sudokuBoard, int valuesToEliminate, int eliminateFromRow, int eliminateFromCol)
        {
            var valuesToEliminateArray = valuesToEliminate.ToString().ToCharArray();
            foreach (var value in valuesToEliminateArray) {
                sudokuBoard[eliminateFromRow, eliminateFromCol] = Convert.ToInt32(sudokuBoard[eliminateFromRow, eliminateFromCol].ToString().Replace(valuesToEliminate.ToString(), string.Empty));
            }
        }

        private bool HasNakedPairInRow(int[,] sudokuBoard, int givenRow, int givenCol)
        {
                for (int column = 0; column < sudokuBoard.GetLength(1); column++)
                {
                    if (givenCol != column && IsNakedPair(sudokuBoard[givenRow, column], sudokuBoard[givenRow, givenCol])) {
                        return true;
                    }
                }
            return false;
        }

        private bool IsNakedPair(int firstPair,int secondPair)
        {
            return firstPair.ToString().Length == 2 && firstPair == secondPair;
        }

        public void EliminateNakedPairFromOthersInColumn(int[,] sudokuBoard, int givenRow, int givenCol) {
            if (!HasNakedPairInColumn(sudokuBoard,givenRow, givenCol))
            {
                return;
            }
            else {
                for (int row = 0; row < sudokuBoard.GetLength(0); row++)
                {
                    if (sudokuBoard[row, givenCol] != sudokuBoard[givenRow, givenCol] && sudokuBoard[givenRow, row].ToString().Length > 1)
                    {
                        EliminateNakedPair(sudokuBoard, sudokuBoard[givenRow, givenCol], givenRow, row);
                    }
                }
            }
        }

        private bool HasNakedPairInColumn(int[,] sudokuBoard,int givenRow,int givenColumn)
        {
            for (int row = 0; row < sudokuBoard.GetLength(0); row++)
            {
                if (givenRow != row && IsNakedPair(sudokuBoard[row, givenColumn], sudokuBoard[givenRow, givenColumn]))
                {
                    return true;
                }

            }
            return false;
        }

        public void EliminateNakedPairFromOthersInBlock(int[,] sudokuBoard, int givenRow, int givenCol)
        {
            if (!HasNakedPairInBlock(sudokuBoard, givenRow, givenCol))
            {
                return;
            }
            else {
                SudokuMap sudokuMap = SudokuMapper.Find(givenRow, givenCol);
                for (int row = sudokuMap.StartRow; row <= sudokuMap.StartRow + 2; row++)
                {
                    for (int column = sudokuMap.StartColumn; column <= sudokuMap.StartColumn + 2; column++)
                    {
                        if (sudokuBoard[row, column].ToString().Length > 1 && sudokuBoard[row, column]!= sudokuBoard[givenRow, givenCol]) {
                            EliminateNakedPair(sudokuBoard, sudokuBoard[givenRow, givenCol], row, column);
                        }
                    }
                }
            }
        }

        private bool HasNakedPairInBlock(int[,] sudokuBoard, int givenRow, int givenCol)
        {
            for (int row = 0; row < sudokuBoard.GetLength(0); row++)
            {
                for (int column = 0; column < sudokuBoard.GetLength(0); column++)
                {
                    bool elementSame = givenRow == row && givenCol == column;
                    bool elementInSameBlock = SudokuMapper.Find(givenRow, givenCol).StartRow == SudokuMapper.Find(row, givenCol).StartRow && SudokuMapper.Find(givenRow, givenCol).StartColumn == SudokuMapper.Find(row, column).StartColumn;
                    if (!elementSame && elementInSameBlock && IsNakedPair(sudokuBoard[givenRow, givenCol], sudokuBoard[row, column])) {
                        return true;
                    }
                }
            }
            return false;
        }

    }
}
