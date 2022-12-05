namespace Advent01
{
    public static class Program
    {
        public static void Main()
        {
            IOrderedEnumerable<int> sorted = File.ReadAllText("data.txt")
                .Split(new[] { "\n\n" }, StringSplitOptions.None)
                .Select(g => g.Split('\n', StringSplitOptions.RemoveEmptyEntries)
                .Select(d => int.Parse(d)))
                .Select(d => d.Sum(n => n))
                .OrderByDescending(p => p);

            // 68802
            Console.WriteLine("part 1:" + sorted
                .First());

            // 205370
            Console.WriteLine("part 2: " + sorted
                .Take(3)
                .Sum());
        }
    }
}