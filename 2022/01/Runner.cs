namespace Day01
{
    public class Runner : IDay
    {
        public void Run()
        {
            IOrderedEnumerable<int> sorted = File.ReadAllText("datafiles/01.txt")
                .Split(new[] { "\n\n" }, StringSplitOptions.None)
                .Select(g => g.Split('\n', StringSplitOptions.RemoveEmptyEntries)
                .Select(d => int.Parse(d)))
                .Select(d => d.Sum(n => n))
                .OrderByDescending(p => p);

            // 68802
            Console.WriteLine("Part 1: " + sorted
                .First());

            // 205370
            Console.WriteLine("Part 2: " + sorted
                .Take(3)
                .Sum());
        }
    }
}