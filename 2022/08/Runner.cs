namespace Day08
{
    public class Runner : IDay
    {
        public void Run()
        {
            string[] lines = File.ReadAllLines("datafiles/08.txt");

            DoPart1(lines);

            DoPart2(lines);
        }

        private static void DoPart1(string[] lines)
        {
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
                for (int j = lines[i].Length - 1; j >= 0; j--)
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
                for (int j = lines[i].Length - 1; j >= 0; j--)
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

        private static void DoPart2(string[] lines)
        {
            int mapScore, highest = 0;

            for (int y = 0; y < lines.Length; y++)
            {
                for (int x = 0; x < lines[0].Length; x++)
                {
                    mapScore = GetScenicScore(lines, x, y);
                    if (mapScore > highest)
                    {
                        highest = mapScore;
                    }
                }
            }

            Console.WriteLine($"Part 2: {highest}");
        }

        private static int GetScenicScore(string[] lines, int x, int y)
        {
            // edges always have a score of 0
            if (x == 0 || y == 0 || x == lines[0].Length - 1 || y == lines.Length - 1)
            {
                return 0;
            }

            List<(int x, int y)> directions = new()
            {
                (0,-1),
                (1,0),
                (0,1),
                (-1,0),
            };
            List<int> scores = new();

            int max = lines[y][x];

            foreach ((int x, int y) dir in directions)
            {
                int val = -1;
                int tempScore = 0;
                int tx = x + dir.x, ty = y + dir.y;

                while (val < max && tx >= 0 && tx < lines.Length && ty >= 0 && ty < lines[0].Length)
                {
                    val = lines[ty][tx];
                    tempScore++;
                    tx += dir.x;
                    ty += dir.y;
                }
                if (tempScore > 0)
                {
                    scores.Add(tempScore);
                }
            }

            if (scores.Count > 0)
            {
                return scores.Aggregate((acc, x) => acc * x);
            }
            return 0;
        }
    }
}