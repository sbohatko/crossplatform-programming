namespace Maharaja
{
    internal class BaseClass
    {
        internal readonly string _inputFile;
        internal readonly string _outputFile;
        internal BaseClass(string inputFile, string outputFile)
        {
            _inputFile = inputFile;
            _outputFile = outputFile;
        }

        internal virtual string Run()
        {
            return "Not implement";
        }
    }
}
