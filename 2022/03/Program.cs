namespace Advent03
{
    public static class Program
    {
        public static void Main()
        {
            string[] sacks = File.ReadAllLines("data.txt");

            int sum = 0;

            foreach (string sack in sacks)
            {
                string comp1 = sack[..(sack.Length / 2)];
                string comp2 = sack[(sack.Length / 2)..];

                char shared = comp1.Intersect(comp2).First();

                sum += GetPriority(shared);
            }

            Console.WriteLine($"Part 1: {sum}");

            sum = 0;

            for (int i = 0; i < sacks.Length; i += 3)
            {
                string sack1 = sacks[i];
                string sack2 = sacks[i + 1];
                string sack3 = sacks[i + 2];

                List<List<char>> lists = new() { sack1.ToList(), sack2.ToList(), sack3.ToList() };
                char intersect = lists.SelectMany(x => x).Distinct().First(w => lists.TrueForAll(t => t.Contains(w)));

                sum += GetPriority(intersect);
            }

            Console.WriteLine($"Part 2: {sum}");
        }

        private static int GetPriority(char c) => c - (char.IsLower(c) ? 'a' - 1 : 'A' - 27);
    }
}