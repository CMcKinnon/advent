namespace Day07
{
    public class Runner : IDay
    {
        public void Run()
        {
            string[] data = File.ReadAllLines("datafiles/07.txt");

            Parser parser = new(data);

            DirEntry root = parser.Parse();

            root.ShowPart1Answer();

            root.ShowPart2Answer();
        }
    }
}