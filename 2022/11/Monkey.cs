namespace Day11
{
    public class Monkey
    {
        public Queue<int> Items { get; set; }
        public Operation Operation { get; set; }

        public int TestDivisor { get; set; }

        public int TrueMonkey { get; set; }

        public int FalseMonkey { get; set; }

        public int InspectionCount { get; set; }

        public Monkey(List<string> input)
        {
            Items = new(input[1].Replace("  Starting items: ", "")
                .Split(',')
                .Select(d => int.Parse(d))
                .ToList());

            string[] operations = input[2].Replace("  Operation: new = old ", "").Split(' ');
            OperationType ot;
            if (operations[0] == "+")
            {
                ot = OperationType.Add;
            }
            else if (operations[0] == "*")
            {
                ot = OperationType.Multiply;
            }
            else
            {
                throw new InvalidOperationException($"Invalid operation type {operations[0]}");
            }
            bool isOld = operations[1] == "old";
            int value = 0;
            if (!isOld)
            {
                value = int.Parse(operations[1]);
            }
            Operation = new(ot, isOld, value);

            TestDivisor = int.Parse(input[3].Replace("  Test: divisible by ", ""));

            TrueMonkey = int.Parse(input[4].Replace("   If true: throw to monkey ", ""));

            FalseMonkey = int.Parse(input[5].Replace("   If false: throw to monkey ", ""));
        }
    }
}