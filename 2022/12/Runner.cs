namespace Day12
{
    public class Runner : IDay
    {
        private (int y, int x) startPos;

        private (int y, int x) endPos;

        public void Run()
        {
            string[] lines = File.ReadAllLines("datafiles/12.txt");

            int[][] map = ParseMap(lines);

            SolvePart1(map);
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
                        startPos = (i, j);
                        val = 0;
                    }
                    else if (lines[i][j] == 'E')
                    {
                        endPos = (i, j);
                        val = 25;
                    }
                    else
                    {
                        val = lines[i][j] - 'a';
                    }
                    map[i][j] = val;
                }
            }

            return map;
        }

        private static void SolvePart1(int[][] map)
        {

        }
    }
}