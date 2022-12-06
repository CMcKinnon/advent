using System.Text.RegularExpressions;
namespace Advent05
{
    public class FileParser
    {
        private readonly string[] data;

        public FileParser(string[] data) => this.data = data;

        public Ship LoadShip()
        {
            Ship ship = new();
            Stack<string>[] stacks = new Stack<string>[9];
            for (int i = 0; i < 9; i++)
            {
                stacks[i] = new Stack<string>();
            }

            foreach (string line in data.TakeWhile(d => d.Contains('[')))
            {
                int idx = 0;

                while ((idx = line.IndexOf('[', idx)) >= 0)
                {
                    char letter = line[idx + 1];
                    stacks[idx / 4].Push(letter.ToString());
                    idx += 2;
                }
            }

            for (int i = 0; i < 9; i++)
            {
                while (stacks[i].Count > 0)
                {
                    ship.Stacks[i].Push(stacks[i].Pop());
                }
            }
            return ship;
        }

        public List<Step> GetSteps()
        {
            Regex regex = new(@"^move\s+(\d+)\s+from\s+(\d+)\s+to\s+(\d+)$", RegexOptions.IgnoreCase | RegexOptions.Compiled);

            IEnumerable<string> lines = data.SkipWhile(d => d.Length > 0).Skip(1);
            return lines.Select(d =>
            {
                Match match = regex.Match(d);
                if (match.Success)
                {
                    return new Step
                    {
                        QtyToMove = int.Parse(match.Groups[1].Value),
                        FromStack = int.Parse(match.Groups[2].Value),
                        ToStack = int.Parse(match.Groups[3].Value)
                    };
                }
                throw new FormatException($"Invalid format on {d}");
            }).ToList();
        }
    }
}