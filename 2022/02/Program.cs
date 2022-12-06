using System;
namespace Advent02
{
    public static class Program
    {
        private static readonly Dictionary<string, int> scores = new()
        {
            ["AX"] = 3,
            ["AY"] = 6,
            ["AZ"] = 0,
            ["BX"] = 0,
            ["BY"] = 3,
            ["BZ"] = 6,
            ["CX"] = 6,
            ["CY"] = 0,
            ["CZ"] = 3
        };

        private static readonly Dictionary<string, string> selections = new()
        {
            ["AX"] = "Z",
            ["AY"] = "X",
            ["AZ"] = "Y",
            ["BX"] = "X",
            ["BY"] = "Y",
            ["BZ"] = "Z",
            ["CX"] = "Y",
            ["CY"] = "Z",
            ["CZ"] = "X"
        };

        private static void Main()
        {
            string[] rounds = File.ReadAllLines("data.txt");

            int score = 0;

            foreach (string round in rounds)
            {
                (string opponent, string me) = round.Split(' ') switch { string[] a => (a[0], a[1]) };

                score += me[0] - 'X' + 1 + scores[opponent + me];
            }

            Console.WriteLine($"Part 1: {score}");

            score = 0;

            foreach (string round in rounds)
            {
                (string opponent, string outcome) = round.Split(' ') switch { string[] a => (a[0], a[1]) };

                string me = selections[opponent + outcome];

                score += me[0] - 'X' + 1 + scores[opponent + me];
            }

            Console.WriteLine($"Part 2: {score}");
        }
    }
}