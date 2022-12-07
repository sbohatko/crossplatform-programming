using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maze
{
    internal class Maze
    {
        public char[,] MazeArray { get; }
        int _zX;
        int _xX;
        public Maze(char[,] mazeArray, int zPos, int xPos)
        {
            MazeArray = mazeArray;
            _zX = zPos;
            _xX = xPos;
        }

        public void LightOn()
        {
            Ray(_zX, _xX, Direction.UpperRight);
            Ray(_zX, _xX, Direction.UpperLeft);
            Ray(_zX, _xX, Direction.LowerLeft);
            Ray(_zX, _xX, Direction.LowerRight);
        }

        private void Ray(int z, int x, Direction direction)
        {
            switch (direction)
            {
                case Direction.UpperRight:
                    RayUpperRight(z, x);
                    break;
                case Direction.LowerRight:
                    RayLowerRight(z, x);
                    break;
                case Direction.UpperLeft:
                    RayUpperLeft(z, x);
                    break;
                case Direction.LowerLeft:
                    RayLowerLeft(z, x);
                    break;
            }
        }

        private void RayLowerLeft(int z, int x)
        {
            if (MazeArray[z + 1,x - 1] == '.' && (MazeArray[z + 1,x] != '*' || MazeArray[z,x - 1] != '*'))
            {
                MazeArray[z + 1,x - 1] = '/';
                Ray(z + 1, x - 1, Direction.LowerLeft); // пошел далее
            }
            else if (MazeArray[z + 1,x - 1] == '\\' && (MazeArray[z + 1,x] != '*' || MazeArray[z,x - 1] != '*'))
            {
                MazeArray[z + 1,x - 1] = 'X';
                Ray(z + 1, x - 1, Direction.LowerLeft); // пошел далее
            }
            else if (MazeArray[z,x - 1] == '*' && MazeArray[z + 1,x - 1] == '*' && MazeArray[z + 1,x] == '.')
            {
                MazeArray[z + 1,x] = '\\';
                Ray(z + 1, x, Direction.LowerRight); // отразился вниз вправо
            }
            else if (MazeArray[z,x - 1] == '*' && MazeArray[z + 1,x - 1] == '*' && MazeArray[z + 1,x] == '/')
            {
                MazeArray[z + 1,x] = 'X';
                Ray(z + 1, x, Direction.LowerRight); // отразился вниз вправо
            }
            else if (MazeArray[z + 1,x] == '*' && MazeArray[z + 1,x - 1] == '*' && MazeArray[z,x - 1] == '.')
            {
                MazeArray[z,x - 1] = '\\';
                Ray(z, x - 1, Direction.UpperLeft); // отразился вверх влево
            }
            if (MazeArray[z + 1,x] == '*' && MazeArray[z + 1,x - 1] == '*' && MazeArray[z,x - 1] == '/')
            {
                MazeArray[z,x - 1] = 'X';
                Ray(z, x - 1, Direction.UpperLeft); // отразился вверх влево
            }
        }

        private void RayUpperLeft(int z, int x)
        {
            if (MazeArray[z - 1,x - 1] == '.' && (MazeArray[z - 1,x] != '*' || MazeArray[z,x - 1] != '*'))
            {
                MazeArray[z - 1,x - 1] = '\\';
                Ray(z - 1, x - 1, Direction.UpperLeft); // пошел далее
            }
            if (MazeArray[z - 1,x - 1] == '/' && (MazeArray[z - 1,x] != '*' || MazeArray[z,x - 1] != '*'))
            {
                MazeArray[z - 1,x - 1] = 'X';
                Ray(z - 1, x - 1, Direction.UpperLeft); // пошел далее
            }
            if (MazeArray[z - 1,x - 1] == '*' && MazeArray[z - 1,x] == '*' && MazeArray[z,x - 1] == '.')
            {
                MazeArray[z,x - 1] = '/';
                Ray(z, x - 1, Direction.LowerLeft); // отразился вниз влево
            }
            if (MazeArray[z - 1,x - 1] == '*' && MazeArray[z - 1,x] == '*' && MazeArray[z,x - 1] == '\\')
            {
                MazeArray[z,x - 1] = 'X';
                Ray(z, x - 1, Direction.LowerLeft); // отразился вниз влево
            }
            if (MazeArray[z - 1,x - 1] == '*' && MazeArray[z,x - 1] == '*' && MazeArray[z - 1,x] == '.')
            {
                MazeArray[z - 1,x] = '/';
                Ray(z - 1, x, Direction.UpperRight); // отразился вверх вправо
            }
            if (MazeArray[z - 1,x - 1] == '*' && MazeArray[z,x - 1] == '*' && MazeArray[z - 1,x] == '\\')
            {
                MazeArray[z - 1,x] = 'X';
                Ray(z - 1, x, Direction.UpperRight); // отразился вверх вправо
            }
        }

        private void RayLowerRight(int z, int x)
        {
            if (MazeArray[z + 1,x + 1] == '.' && (MazeArray[z + 1,x] != '*' || MazeArray[z,x + 1] != '*'))
            {
                MazeArray[z + 1,x + 1] = '\\';
                Ray(z + 1, x + 1, Direction.LowerRight); // пошел далее
            }
            if (MazeArray[z + 1,x + 1] == '/' && (MazeArray[z + 1,x] != '*' || MazeArray[z,x + 1] != '*'))
            {
                MazeArray[z + 1,x + 1] = 'X';
                Ray(z + 1, x + 1, Direction.LowerRight); // пошел далее
            }
            if (MazeArray[z + 1,x + 1] == '*' && MazeArray[z + 1,x] == '*' && MazeArray[z,x + 1] == '.')
            {
                MazeArray[z,x + 1] = '/';
                Ray(z, x + 1, Direction.UpperRight); // отразился вверх вправо
            }
            if (MazeArray[z + 1,x + 1] == '*' && MazeArray[z + 1,x] == '*' && MazeArray[z,x + 1] == '\\')
            {
                MazeArray[z,x + 1] = 'X';
                Ray(z, x + 1, Direction.UpperRight); // отразился вверх вправо
            }
            if (MazeArray[z + 1,x + 1] == '*' && MazeArray[z,x + 1] == '*' && MazeArray[z + 1,x] == '.')
            {
                MazeArray[z + 1,x] = '/';
                Ray(z + 1, x, Direction.LowerLeft); // отразился вниз влево
            }
            if (MazeArray[z + 1,x + 1] == '*' && MazeArray[z,x + 1] == '*' && MazeArray[z + 1,x] == '\\')
            {
                MazeArray[z + 1,x] = 'X';
                Ray(z + 1, x, Direction.LowerLeft); // отразился вниз влево
            }
        }

        private void RayUpperRight(int z, int x)
        {
            if (MazeArray[z - 1,x + 1] == '.' && (MazeArray[z - 1,x] != '*' || MazeArray[z,x + 1] != '*'))
            {
                MazeArray[z - 1,x + 1] = '/';
                Ray(z - 1, x + 1, Direction.UpperRight); // пошел далее
            }
            if (MazeArray[z - 1,x + 1] == '\\' && (MazeArray[z - 1,x] != '*' || MazeArray[z,x + 1] != '*'))
            {
                MazeArray[z - 1,x + 1] = 'X';
                Ray(z - 1, x + 1, Direction.UpperRight); // пошел далее
            }
            if (MazeArray[z - 1,x + 1] == '*' && MazeArray[z,x + 1] == '*' && MazeArray[z - 1,x] == '.')
            {
                MazeArray[z - 1,x] = '\\';
                Ray(z - 1, x, Direction.UpperLeft); // отразился вверх влево
            }
            if (MazeArray[z - 1,x + 1] == '*' && MazeArray[z,x + 1] == '*' && MazeArray[z - 1,x] == '/')
            {
                MazeArray[z - 1,x] = 'X';
                Ray(z - 1, x, Direction.UpperLeft); // отразился вверх влево
            }
            if (MazeArray[z - 1,x] == '*' && MazeArray[z - 1,x + 1] == '*' && MazeArray[z,x + 1] == '.')
            {
                MazeArray[z,x + 1] = '\\';
                Ray(z, x + 1, Direction.LowerRight); // отразился вниз право
            }
            if (MazeArray[z - 1,x] == '*' && MazeArray[z - 1,x + 1] == '*' && MazeArray[z,x + 1] == '/')
            {
                MazeArray[z,x + 1] = 'X';
                Ray(z, x + 1, Direction.LowerRight); // отразился вниз право
            }
            return;
        }

    }
}
