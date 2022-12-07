namespace Advent07
{
    public static class Program
    {
        private static void Main()
        {
            string[] data = File.ReadAllLines("data.txt");

            Parser parser = new(data);

            DirEntry root = parser.Parse();

            root.Display();

            root.ShowPart1Answer();
        }
    }
}