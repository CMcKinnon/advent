using System.Text.Json;

namespace Day13
{
    public class Runner : IDay
    {
        public void Run()
        {
            string text = File.ReadAllText("datafiles/13.txt");

            var input = text.Split($"{Environment.NewLine}{Environment.NewLine}")
                .Select(p => p.Split(Environment.NewLine))
                .Select(p => (first: JsonDocument.Parse(p[0]).RootElement, second: JsonDocument.Parse(p[1]).RootElement));
        }
    }
}
