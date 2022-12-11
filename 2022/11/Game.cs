namespace Day11
{
    public class Game
    {
        private readonly List<Monkey> monkeys;

        public Game(List<Monkey> monkeys) => this.monkeys = monkeys;

        public void SolvePart1()
        {
            for (int i = 0; i < 20; i++)
            {
                foreach (Monkey monkey in monkeys)
                {
                    ProcessMonkey(monkey);
                }
            }

            IEnumerable<Monkey> activeMonkeys = monkeys.OrderByDescending(m => m.InspectionCount).Take(2);
            Console.WriteLine($"Part 1: {activeMonkeys.First().InspectionCount * activeMonkeys.Last().InspectionCount}");
        }

        private void ProcessMonkey(Monkey monkey)
        {
            while (monkey.Items.Count > 0)
            {
                int item = monkey.Items.Dequeue();
                item = GetNewValue(monkey.Operation, item);
                item /= 3;
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

        private static int GetNewValue(Operation operation, int item)
            => operation.Type == OperationType.Add
                ? item + operation.Value
                : item * (operation.IsOldNumber ? item : operation.Value);
    }
}