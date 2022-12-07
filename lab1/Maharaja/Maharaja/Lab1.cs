using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maharaja
{
    internal class Lab1 : BaseClass
    {
        internal Lab1(string inputFile, string outputFile) : base(inputFile, outputFile)
        {
        }

        internal override string Run()
        {
            Tuple<int, int> inputData = ReadInputData();
            string result = Solve(inputData.Item1, inputData.Item2);
            WriteOutputData(result);
            return result;
        }

        private void WriteOutputData(string result)
        {
            File.WriteAllText(_outputFile, result);
        }

        internal string Solve(int boardSize, int piecesCount)
        {
            Board board = new Board(boardSize, piecesCount);
            string res = board.Solve();
            return res;
        }

        private Tuple<int, int> ReadInputData()
        {
            string[] data = File.ReadAllText(_inputFile).Split(' ');
            if (data.Length == 2
                && int.TryParse(data[0], out int boardSize)
                && int.TryParse(data[1], out int piecesCount))
            {
                return new Tuple<int, int>(boardSize, piecesCount);
            }
            return new Tuple<int, int>(0, 0);

        }
    }
}
