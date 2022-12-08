namespace Day08
{
    public class Runner : IDay
    {
        public void Run()
        {
            string[] lines = File.ReadAllLines("datafiles/08.txt");

            HashSet<(int, int)> visibleTrees = new();

            // check from left
            for (int i = 0; i < lines.Length; i++)
            {
                int tallest = -1;
                for (int j = 0; j < lines[i].Length; j++)
                {
                    int current = lines[i][j] - '0';
                    if (current > tallest)
                    {
                        tallest = current;
                        visibleTrees.Add((j, i));
                    }
                }
            }

            // check from right
            for (int i = 0; i < lines.Length; i++)
            {
                int tallest = -1;
                for (int j=lines[i].Length - 1; j>=0; j--)
                {
                    int current = lines[i][j] - '0';
                    if (current > tallest)
                    {
                        tallest = current;
                        visibleTrees.Add((j, i));
                    }
                }
            }

            // check from top
            for (int i = 0; i < lines.Length; i++)
            {
                int tallest = -1;
                for (int j = 0; j < lines[i].Length; j++)
                {
                    int current = lines[j][i] - '0';
                    if (current > tallest)
                    {
                        tallest = current;
                        visibleTrees.Add((i, j));
                    }
                }
            }

            // check from bottom
            for (int i = 0; i < lines.Length; i++)
            {
                int tallest = -1;
                for (int j=lines[i].Length - 1; j>=0; j--)
                {
                    int current = lines[j][i] - '0';
                    if (current > tallest)
                    {
                        tallest = current;
                        visibleTrees.Add((i, j));
                    }
                }
            }

            Console.WriteLine($"Part 1: {visibleTrees.Count}");
        }
    }
}