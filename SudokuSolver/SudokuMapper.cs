using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SudokuSolver
{
    class SudokuMapper
    {
        public SudokuMap Find(int givenRow, int givenColumn) {
            SudokuMap sudokuMap = new SudokuMap();
            if ((givenRow >= 0 && givenRow <= 2) && (givenColumn >= 0 && givenColumn <= 2))
            {
                sudokuMap.StartRow = 0;
                sudokuMap.StartColumn = 0;
            }
            else if ((givenRow >= 0 && givenRow <= 2) && (givenColumn >= 3 && givenColumn <= 5)) {
                sudokuMap.StartRow = 3;
                sudokuMap.StartColumn = 5;
            }
            else if ((givenRow >= 0 && givenRow <= 2) && (givenColumn >= 6 && givenColumn <= 8))
            {
                sudokuMap.StartRow = 0;
                sudokuMap.StartColumn = 6;
            }
            else if ((givenRow >= 3 && givenRow <= 5) && (givenColumn >= 0 && givenColumn <= 2))
            {
                sudokuMap.StartRow = 3;
                sudokuMap.StartColumn = 0;
            }
            else if ((givenRow >= 3 && givenRow <= 5) && (givenColumn >= 3 && givenColumn <= 5))
            {
                sudokuMap.StartRow = 3;
                sudokuMap.StartColumn = 3;
            }
            else if ((givenRow >= 3 && givenRow <= 5) && (givenColumn >= 6 && givenColumn <= 8))
            {
                sudokuMap.StartRow = 3;
                sudokuMap.StartColumn = 6;
            }
            else if ((givenRow >= 6 && givenRow <= 8) && (givenColumn >= 0 && givenColumn <= 2))
            {
                sudokuMap.StartRow = 6;
                sudokuMap.StartColumn = 0;
            }
            else if ((givenRow >= 6 && givenRow <= 8) && (givenColumn >= 3 && givenColumn <= 5))
            {
                sudokuMap.StartRow = 6;
                sudokuMap.StartColumn = 3;
            }
            else if ((givenRow >= 6 && givenRow <= 8) && (givenColumn >= 6 && givenColumn <= 8))
            {
                sudokuMap.StartRow = 6;
                sudokuMap.StartColumn = 8;
            }
            return sudokuMap;
        }
    }
}
