namespace Maharaja
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Lab1 lab1 = new Lab1("input.txt", "output.txt");
            Console.WriteLine(lab1.Run());
        }

    }
}