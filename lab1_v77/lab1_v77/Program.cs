using System;
using System.IO;
using System.Text.RegularExpressions;

namespace lab1_v77
{
    class Program
    {

        public static int[] my = new int[10];
        public static int[] mx = new int[10];
        public static int n;
        public static int k;
        public static int count = 0;
        public static int dx;
        public static int dy;

        public static void Check(int p)
        {
            bool strike;
            for (int y = (p != 0 ? my[p - 1] + 1 : 1); y <= n; y++)
            {
                for (int x = 1; x <= n; x++)
                {
                    strike = false;
                    for (int i = 0; i < p; i++)
                    {
                        dy = Math.Abs(my[i] - y);
                        dx = Math.Abs(mx[i] - x);
                        if (dx == 0 || dy == 0 || dx == dy || dx * dy == 2)
                        {
                            strike = true;
                            break;
                        }
                    }
                    if (!strike && p < k - 1)
                    {
                        mx[p] = x;
                        my[p] = y;
                        Check(p + 1);
                    }
                    else
                    {
                        count++;
                    }
                }
            }
        }
        static void Main(string[] args)
        {
            var numOfInputs = 3;
            for (var i = 1; i <= numOfInputs; i++)
            {
                StreamReader sr = new StreamReader(@"/Users/alexbogatko/Documents/GitHub/crossplatform-programming/lab1_v77/lab1_v77/input"+i+".txt");
                var set = sr.ReadToEnd().Split(' ');
                n = int.Parse(set[0]);
                k = int.Parse(set[1]);
                Check(k);
                Console.Write(count+ "\n\n");
            }
            Console.ReadKey();
        }
    }
}
