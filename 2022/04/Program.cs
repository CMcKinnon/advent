namespace Advent04
{
    public static class Program
    {
        private static void Main()
        {
            string[] pairs = File.ReadAllLines("data.txt");

            int completeOverlaps = 0, partialOverlaps = 0;

            foreach (string pair in pairs)
            {
                string[] elves = pair.Split(',');
                string[] elf1 = elves[0].Split('-');
                string[] elf2 = elves[1].Split('-');

                (int low1, int hi1) = elf1 switch { string[] a => (int.Parse(a[0]), int.Parse(a[1])) };
                (int low2, int hi2) = elf2 switch { string[] a => (int.Parse(a[0]), int.Parse(a[1])) };

                if ((low1 <= low2 && hi1 >= hi2) || (low2 <= low1 && hi2 >= hi1))
                {
                    completeOverlaps++;
                }

                IEnumerable<int> range1 = Enumerable.Range(low1, hi1 - low1 + 1);
                IEnumerable<int> range2 = Enumerable.Range(low2, hi2 - low2 + 1);
                IEnumerable<int> intersect = range1.Intersect(range2);

                if (intersect.Any())
                {
                    partialOverlaps++;
                }
            }

            Console.WriteLine($"Part 1: {completeOverlaps}"); // 580

            Console.WriteLine($"Part 2: {partialOverlaps}"); // 895
        }
    }
}