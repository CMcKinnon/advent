using System.Text.Json;

namespace Day13
{
    public class Runner : IDay
    {
        public void Run()
        {
            string text = File.ReadAllText("datafiles/13.txt");

            IEnumerable<(JsonElement first, JsonElement second)> input = text.Split($"{Environment.NewLine}{Environment.NewLine}")
                .Select(p => p.Split(Environment.NewLine))
                .Select(p => (first: JsonDocument.Parse(p[0]).RootElement, second: JsonDocument.Parse(p[1]).RootElement));

            int i = 0, sum = 0;
            foreach (var pair in input)
            {
                i++;
                int result = ComparePair(pair);

                if (result < 0)
                {
                    sum += i;
                }
            }

            Console.WriteLine($"Part 1: {sum}");

            IOrderedEnumerable<JsonElement> part2input = input
                .SelectMany(p => new JsonElement[] {p.first, p.second})
                .Append(JsonDocument.Parse("[[2]]").RootElement)
                .Append(JsonDocument.Parse("[[6]]").RootElement)
                .OrderBy(p => p, Comparer<JsonElement>.Create((f, s) => ComparePair((f, s))));

            int div1 = part2input
                .Select((p, i) => (pkt: p, idx: i + 1))
                .First(i => ComparePair((i.pkt, JsonDocument.Parse("[[2]]").RootElement)) == 0).idx;

            int div2 = part2input
                .Select((p, i) => (pkt: p, idx: i + 1))
                .First(i => ComparePair((i.pkt, JsonDocument.Parse("[[6]]").RootElement)) == 0).idx;

            Console.WriteLine($"Part 2: {div1 * div2}");
        }

        private int ComparePair((JsonElement first, JsonElement second) pair)
        {
            if (pair.first.ValueKind == JsonValueKind.Number && pair.second.ValueKind == JsonValueKind.Number)
            {
                return pair.first.GetInt32() - pair.second.GetInt32();
            }
            else if (pair.first.ValueKind == JsonValueKind.Number)
            {
                return ComparePair((JsonDocument.Parse($"[{pair.first.GetInt32()}]").RootElement, pair.second));
            }
            else if (pair.second.ValueKind == JsonValueKind.Number)
            {
                return ComparePair((pair.first, JsonDocument.Parse($"[{pair.second.GetInt32()}]").RootElement));
            }
            else
            {
                foreach (var (nextFirst, nextSecond) in pair.first.EnumerateArray().Zip(pair.second.EnumerateArray()))
                {
                    var current = ComparePair((nextFirst, nextSecond));
                    if (current == 0)
                    {
                        continue;
                    }
                    else
                    {
                        return current;
                    }
                }
            }

            return pair.first.GetArrayLength() - pair.second.GetArrayLength();
        }
    }
}
