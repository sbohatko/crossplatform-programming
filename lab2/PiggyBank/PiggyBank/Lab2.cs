using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PiggyBank
{
    internal class Lab2 : BaseClass
    {
        private int _emptyWeight;
        private int _fullWeight;
        private int _coinTypesCount;
        private int[] _coinType;
        private int[] _coinWeight;
        int[] _min;
        int[] _max;
        internal Lab2(string inputFile, string outputFile) : base(inputFile, outputFile)
        {
        }

        internal string Run()
        {
            ReadInputData();
            string result = Solve();
            WriteOutputData(result);
            return result;
        }

        private void WriteOutputData(string result)
        {
            File.WriteAllText(_outputFile, result);
        }

        private string Solve()
        {
            InitMinMaxArrays();
            _min[0] = 0;
            _max[0] = 0;
            for (int i = 0; i < _min.Length; i++)
            {
                for (int j = 0; j < _coinWeight.Length; j++)
                {
                    if (i - _coinWeight[j] >= 0 && _min[i - _coinWeight[j]] != int.MaxValue)
                    {
                        _min[i] = Math.Min(_min[i], _min[i - _coinWeight[j]] + _coinType[j]);
                        _max[i] = Math.Max(_max[i], _max[i - _coinWeight[j]] + _coinType[j]);
                    }
                }
            }
            return (_min[_min.Length - 1] == int.MaxValue) ? "This is impossible." : $"{_min[_min.Length - 1]} {_max[_max.Length - 1]}";


        }

        private void InitMinMaxArrays()
        {
            _min = new int[_fullWeight - _emptyWeight + 1];
            _max = new int[_fullWeight - _emptyWeight + 1];
            FillArray(_min, int.MaxValue);
            FillArray(_max, int.MinValue);
        }

        private void FillArray(int[] arr, int val)
        {
            for(int i = 0; i < arr.Length; i++)
            {
                arr[i] = val;
            }
        }

        private void ReadInputData()
        {
            StreamReader reader = new StreamReader(_inputFile);
            string line = reader.ReadLine();
            Tuple<int, int> val = GetPairInput(line);
            _emptyWeight = val.Item1;
            _fullWeight = val.Item2;
            line = reader.ReadLine();
            if (int.TryParse(line, out int coinTypesCount))
            {
                _coinTypesCount = coinTypesCount;
                InitArrays();
                for(int i = 0; i < _coinTypesCount; i++)
                {
                    line = reader.ReadLine();
                    val = GetPairInput(line);
                    _coinType[i] = val.Item1;
                    _coinWeight[i] = val.Item2;
                }
            }
            reader.Close();
        }

        private void InitArrays()
        {
            _coinType = new int[_coinTypesCount];
            _coinWeight = new int[_coinTypesCount];
        }

        private Tuple<int, int> GetPairInput(string? line)
        {
            string[] pair = line.Split(' ');
            int.TryParse(pair[0], out int i);
            int.TryParse(pair[1], out int j);
            return Tuple.Create(i, j);
        }
    }
}
