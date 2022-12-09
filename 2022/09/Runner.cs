namespace Day09
{
    public class Runner : IDay
    {
        public void Run()
        {
            string[] moves = File.ReadAllLines("datafiles/09.txt");

            HashSet<(int, int)> tailVisits = new();

            Node head = new();
            Node tail = new();

            // starting position
            tailVisits.Add((0, 0));

            foreach (string move in moves)
            {
                (int xMove, int yMove, int count) = ParseMove(move);

                Console.WriteLine(move);

                for (int i = 0; i < count; i++)
                {
                    head.X += xMove;
                    head.Y += yMove;

                    MoveTail(head, tail, tailVisits);

                    Console.WriteLine($" head => ({head.X}, {head.Y})  tail => ({tail.X}, {tail.Y})");
                }
            }

            Console.WriteLine($"Part 1: {tailVisits.Count}");
        }

        private static void MoveTail(Node head, Node tail, HashSet<(int, int)> tailVisits)
        {
            int xDelta = head.X - tail.X;
            int yDelta = head.Y - tail.Y;

            Console.Write($"  xDelta = {xDelta}  yDelta = {yDelta}");

            if (xDelta == 0 && yDelta == 2)
            {
                Console.WriteLine(" up");
                tail.Y++;
            }
            else if (xDelta == 0 && yDelta == -2)
            {
                Console.WriteLine(" down");
                tail.Y--;
            }
            else if (yDelta == 0 && xDelta == 2)
            {
                Console.WriteLine(" right");
                tail.X++;
            }
            else if (yDelta == 0 && xDelta == -2)
            {
                Console.WriteLine(" left");
                tail.X--;
            }
            else if ((xDelta == 1 && yDelta == -2) || (xDelta == 2 && yDelta == -1))
            {
                Console.WriteLine(" right/down");
                tail.X++;
                tail.Y--;
            }
            else if ((xDelta == -2 && yDelta == 1) || (xDelta == -1 && yDelta == 2))
            {
                Console.WriteLine(" left/up");
                tail.X--;
                tail.Y++;
            }
            else if ((xDelta == 1 && yDelta == 2) || (xDelta == 2 && yDelta == 1))
            {
                Console.WriteLine(" right/up");
                tail.X++;
                tail.Y++;
            }
            else if ((xDelta == -2 && yDelta == -1) || (xDelta == -1 && yDelta == -2))
            {
                Console.WriteLine(" left/down");
                tail.X--;
                tail.Y--;
            }
            else
            {
                Console.WriteLine(" no move");
            }

            tailVisits.Add((tail.X, tail.Y));
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