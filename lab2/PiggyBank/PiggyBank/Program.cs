namespace PiggyBank
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Lab2 lab2 = new Lab2("input.txt", "output.txt");
            Console.WriteLine(lab2.Run());
        }
    }
}