using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Maharaja
{
    internal class Board
    {
        private int _boardSize;
        private int _piecesCount;
        private int[] _pos;
        private int _variantsCount;
        public Board(int boardSize, int piecesCount)
        {
            _boardSize = boardSize;
            _piecesCount = piecesCount;
            _pos = new int[_boardSize];
        }
        internal string Solve()
        {
            _variantsCount = 0;
            Solve(0, 0);
            return _variantsCount.ToString();
        }

        private void Solve(int row, int pieceIndex)
        {
            if (row == _boardSize)
            {
                if (pieceIndex == _piecesCount)
                    _variantsCount++;
                return;
            }
            for (int col = -1; col < (pieceIndex == _piecesCount ? 0 : _boardSize); col++)
            {
                if (Test(row, col, 0))
                {
                    _pos[row] = col;
                    Solve(row + 1, pieceIndex + (col >= 0 ? 1 : 0));
                }
            }
        }

        private bool Test(int row, int col, int chekRow)
        {
            int x;
            int y;
            x = row - chekRow;
            y = col - _pos[chekRow]; 
            x *= x; 
            y *= y;
            bool isFirstCol = col < 0;
            bool isLastRow = chekRow == row;
            return isFirstCol 
                || isLastRow 
                || ((_pos[chekRow] < 0 || (y != 0 && x != y && x + y != 5)) && Test(row, col, chekRow + 1));
        }
    }
}
