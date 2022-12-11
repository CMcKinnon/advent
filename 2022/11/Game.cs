namespace Day11
{
    public class Game
    {
        private readonly List<Monkey> monkeys;

        private readonly ulong modulo;

        public Game(List<Monkey> monkeys)
        {
            this.monkeys = monkeys;
            modulo = monkeys.Select(x => x.TestDivisor).Aggregate((x, y) => x * y);
        }

        public void SolvePart1()
        {
            for (int i = 0; i < 20; i++)
            {
                foreach (Monkey monkey in monkeys)
                {
                    ProcessMonkey(monkey, true);
                }
            }

            IEnumerable<Monkey> activeMonkeys = monkeys.OrderByDescending(m => m.InspectionCount).Take(2);
            Console.WriteLine($"Part 1: {activeMonkeys.First().InspectionCount * activeMonkeys.Last().InspectionCount}");
        }

        public void SolvePart2()
        {
            for (int i = 0; i < 10000; i++)
            {
                foreach (Monkey monkey in monkeys)
                {
                    ProcessMonkey(monkey, false);
                }
            }

            IEnumerable<Monkey> activeMonkeys = monkeys.OrderByDescending(m => m.InspectionCount).Take(2);
            Console.WriteLine($"Part 2: {activeMonkeys.First().InspectionCount * activeMonkeys.Last().InspectionCount}");
        }

        private void ProcessMonkey(Monkey monkey, bool reduceWorry)
        {
            while (monkey.Items.Count > 0)
            {
                ulong item = monkey.Items.Dequeue();
                item = GetNewValue(monkey.Operation, item);
                if (reduceWorry)
                {
                    item /= 3;
                }
                if (item % monkey.TestDivisor == 0)
                {
                    monkeys[monkey.TrueMonkey].Items.Enqueue(item);
                }
                else
                {
                    monkeys[monkey.FalseMonkey].Items.Enqueue(item);
                }
                monkey.InspectionCount++;
            }
        }

        private ulong GetNewValue(Operation operation, ulong item)
        {
            if (operation.Type == OperationType.Add)
            {
                return item + operation.Value;
            }
            else
            {
                ulong multiplier = operation.IsOldNumber ? item : operation.Value;
                return item * multiplier % modulo;
            }
        }
    }
}