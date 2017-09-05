using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SudokuSolver
{
    class SudokuSolverEngine
    {
        private readonly SudokuBoardStateManager SudokuBoardStateManager;
        private readonly SudokuMapper SudokuMapper;
        public SudokuSolverEngine(SudokuBoardStateManager sudokuBoardStateManager,SudokuMapper sudokuMapper)
        {
            SudokuBoardStateManager = sudokuBoardStateManager;
            SudokuMapper = sudokuMapper;
        }

        public bool Solve(int[,] sudokuBoard) {
            List<ISudokuStrategy> strategies = new List<ISudokuStrategy>();
            strategies.Add(new SimpleMarkupStrategy(SudokuMapper));
            strategies.Add(new NakedPairsStrategy(SudokuMapper));
            var currentState = SudokuBoardStateManager.GenerateState(sudokuBoard);
            var nextState = SudokuBoardStateManager.GenerateState(strategies.First().Solve(sudokuBoard));
            while (!SudokuBoardStateManager.isSolved(sudokuBoard) && currentState != nextState) {
                currentState = nextState;
                foreach (var strategy in strategies) {
                    nextState = SudokuBoardStateManager.GenerateState(strategy.Solve(sudokuBoard));
                }
            }
            return SudokuBoardStateManager.isSolved(sudokuBoard);
        }

    }
}
