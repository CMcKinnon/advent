namespace Day11
{
    public class Runner : IDay
    {
        public void Run()
        {
            List<string> input = File.ReadAllLines("datafiles/11.txt").ToList();
            List<Monkey> monkeys = ParseMonkeys(input);

            Game game = new(monkeys);

            game.SolvePart1();

            // reset items and counts
            monkeys = ParseMonkeys(input);
            game = new(monkeys);

            game.SolvePart2();
        }

        private static List<Monkey> ParseMonkeys(List<string> input)
        {
            if (input.Last().Trim().Length != 0)
            {
                input.Add(string.Empty);
            }

            List<Monkey> monkeys = new();
            List<string> lines = new();

            foreach (string line in input)
            {
                if (line != string.Empty)
                {
                    lines.Add(line);
                }
                else
                {
                    monkeys.Add(new Monkey(lines));
                    lines.Clear();
                }
            }

            return monkeys;
        }
    }
}