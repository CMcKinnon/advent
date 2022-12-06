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

                sum += shared - (char.IsLower(shared) ? 'a' - 1 : 'A' - 27);
            }

            Console.WriteLine($"Part 1: {sum}");
        }
    }
}