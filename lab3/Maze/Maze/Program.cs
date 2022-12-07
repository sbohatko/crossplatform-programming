namespace Maze
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Lab3 lab3 = new Lab3("input.txt", "output.txt");
            Console.WriteLine(lab3.Run());
        }
    }
}