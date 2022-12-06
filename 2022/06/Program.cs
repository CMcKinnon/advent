namespace Advent06
{
    public static class Program
    {
        private static void Main()
        {
            foreach (string line in File.ReadAllLines("data.txt"))
            {
                ProcessLine("Part 1: ", line, 4);
                ProcessLine("Part 2: ", line, 14);
            }
        }

        public static void ProcessLine(string msg, string line, int count)
        {
            for (int i = count; i < line.Length; i++)
            {
                if (line[(i - count)..i].Distinct().Count() == count)
                {
                    Console.WriteLine($"{msg}{i}");
                    break;
                }
            }
        }
    }
}