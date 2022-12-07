using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maze
{
    internal class Lab3 : BaseClass
    {
        int _n;
        int _m;
        char[,] _a;
        private int _zX;
        private int _xX;

        internal Lab3(string inputFile, string outputFile) : base(inputFile, outputFile)
        {
        }

        public string Run()
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
            Maze maze = new Maze(_a, _zX, _xX);
            maze.LightOn();

            var a = maze.MazeArray;

            string s = "";
            for (int i = 1; i < _n + 1; i++)
            {
                for (int j = 1; j < _m + 1; j++)
                {
                    s += a[i, j];
                }
                s += "\r\n";
            }
            return s;

        }


        private void ReadInputData()
        {
            StreamReader sr = new StreamReader(_inputFile);
            string l = sr.ReadLine();
            string[] items = l.Split(' ');
            int.TryParse(items[0], out _n);
            int.TryParse(items[1], out _m);
            _a = new char[_n+2,_m+2];
            for (int z = 0; z < 2 + _n; z++) _a[z,0] = _a[z,_m + 1] = '*'; // отбиваем границы
            for (int z = 0; z < 2 + _m; z++) _a[0,z] = _a[_n + 1,z] = '*';
            for (int z = 0; z < _n; z++)
            {
                l = sr.ReadLine();
                for (int x = 0; x < _m; x++)
                {
                    char c = l[x];
                    _a[z + 1, x + 1] = c;
                    if (c == 'X')
                    { // нашли координаты светофора
                        _zX = z + 1;
                        _xX = x + 1;
                    }
                }
            }
            sr.Close();
        }
    }
}
