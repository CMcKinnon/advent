namespace Day09
{
    public class Runner : IDay
    {
        public void Run()
        {
            string[] moves = File.ReadAllLines("datafiles/09.txt");

            SolvePart1(moves);

            SolvePart2(moves);
        }

        private static void SolvePart1(string[] moves)
        {
            HashSet<(int, int)> tailVisits = new();

            Node head = new();
            Node tail = new() { IsFinalNode = true };

            // starting position
            tailVisits.Add((0, 0));

            foreach (string move in moves)
            {
                (int xMove, int yMove, int count) = ParseMove(move);


                for (int i = 0; i < count; i++)
                {
                    head.X += xMove;
                    head.Y += yMove;

                    MoveTail(head, tail, tailVisits);
                }
            }

            Console.WriteLine($"Part 1: {tailVisits.Count}");
        }

        private static void SolvePart2(string[] moves)
        {
            HashSet<(int, int)> tailVisits = new();

            List<Node> nodes = new();

            for (int i = 0; i < 10; i++)
            {
                nodes.Add(new Node() { IsFinalNode = i == 9 });
            }

            // starting position
            tailVisits.Add((0, 0));

            foreach (string move in moves)
            {
                (int xMove, int yMove, int count) = ParseMove(move);

                for (int i = 0; i < count; i++)
                {
                    nodes[0].X += xMove;
                    nodes[0].Y += yMove;

                    for (int j = 0; j < 9; j++)
                    {
                        MoveTail(nodes[j], nodes[j + 1], tailVisits);
                    }
                }
            }

            Console.WriteLine($"Part 2: {tailVisits.Count}");
        }

        private static void MoveTail(Node head, Node tail, HashSet<(int, int)> tailVisits)
        {
            int xDelta = head.X - tail.X;
            int yDelta = head.Y - tail.Y;

            if (Math.Abs(xDelta) > 1 || Math.Abs(yDelta) > 1)
            {
                tail.X += Math.Sign(xDelta);
                tail.Y += Math.Sign(yDelta);
            }

            if (tail.IsFinalNode)
            {
                tailVisits.Add((tail.X, tail.Y));
            }
        }

        private static (int, int, int) ParseMove(string move)
        {
            string[] parts = move.Split(' ');

            int count = int.Parse(parts[1]);

            return parts[0] switch
            {
                "R" => (1, 0, count),
                "L" => (-1, 0, count),
                "D" => (0, -1, count),
                "U" => (0, 1, count),
                _ => throw new InvalidDataException($"Unkown direction {parts[1]}")
            };
        }
    }
}