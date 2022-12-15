using System.Collections.Generic;

namespace Day12
{
    public class Runner : IDay
    {
        private (int x, int y) startPos;

        private (int x, int y) endPos;

        public void Run()
        {
            string[] lines = File.ReadAllLines("datafiles/12.txt");

            int[][] map = ParseMap(lines);

            SolvePart1(map);
            SolvePart2(map);
        }

        private int[][] ParseMap(string[] lines)
        {
            int h = lines.Length;
            int w = lines[0].Length;

            int[][] map = new int[h][];

            for (int i = 0; i < h; i++)
            {
                map[i] = new int[w];
                for (int j = 0; j < w; j++)
                {
                    int val;

                    if (lines[i][j] == 'S')
                    {
                        startPos = (j, i);
                        val = 1;
                    }
                    else if (lines[i][j] == 'E')
                    {
                        endPos = (j, i);
                        val = 26;
                    }
                    else
                    {
                        val = lines[i][j] - 'a' + 1;
                    }
                    map[i][j] = val;
                }
            }

            return map;
        }

        private void SolvePart1(int[][] map)
        {
            int pathCount = GetShortestPath(map, false);

            Console.WriteLine($"Part 1: {pathCount}");
        }

        private void SolvePart2(int[][] map)
        {
            int pathCount = GetShortestPath(map, true);

            Console.WriteLine($"Part 2: {pathCount}");
        }

        private int GetShortestPath(int[][] map, bool part2)
        {
            int height = map.Length;
            int width = map[0].Length;

            List<(int x, int y)> directions = new() { (-1, 0), (1, 0), (0, -1), (0, 1) };

            Queue<((int x, int y), int step)> queue = new();
            HashSet<(int x, int y)> visited = new();

            if (part2)
            {
                for (int y=0; y<height; y++)
                {
                    for (int x=0; x<width; x++)
                    {
                        if (map[y][x] == 1)
                        {
                            queue.Enqueue(((x, y), 0));
                        }
                    }
                }
            }
            else
            {
                queue.Enqueue((startPos, 0));
            }

            while (queue.Any())
            {
                ((int x, int y), int step) = queue.Dequeue();

                if (!visited.Add((x, y)))
                {
                    continue;
                }

                if (endPos.x == x && endPos.y == y)
                {
                    return step;
                }

                foreach ((int xd, int yd) in directions)
                {
                    int newX = x + xd, newY = y + yd;

                    if ((newX >= 0 && newX < width) && (newY >= 0 && newY < height))
                    {
                        var parentNode = map[y][x];
                        var childNode = map[newY][newX];

                        if (childNode - parentNode <= 1)
                        {
                            queue.Enqueue(((newX, newY), step + 1));
                        }
                    }
                }
            }

            return 0;
        }
    }
}